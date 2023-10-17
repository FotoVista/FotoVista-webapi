using FotoVista.DataAccess.UnitOfWork;
using FotoVista.Domain.Entity;
using FotoVista.Domain.Exceptions.Auth;
using FotoVista.Domain.Exceptions.Users;
using FotoVista.Service.Common;
using FotoVista.Service.DTOs;
using FotoVista.Service.Helpers;
using FotoVista.Service.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace FotoVista.Service.Services;

public class AuthAdminService : IAuthAdminService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IMailSender _mailSender;
    private readonly ITokenAdminService _tokenService;
    private readonly IUnitOfWork _unitOfWork;
    private const int CACHED_MINUTES_FOR_REGISTER = 60;
    private const int CACHED_MINUTES_FOR_VERIFICATION = 50;
    private const string REGISTER_CACHE_KEY = "register_";
    private const string VERIFY_REGISTER_CACHE_KEY = "verify_register_";
    private const int VERIFICATION_MAXIMUM_ATTEMPTS = 3;

    public AuthAdminService(IMemoryCache memoryCache,
            IMailSender smsSender, IUnitOfWork unitOfWork,
            ITokenAdminService tokenAdminService)
    {
        this._memoryCache = memoryCache;
        this._mailSender = smsSender;
        this._tokenService = tokenAdminService;
        this._unitOfWork = unitOfWork;
    }


    public async Task<(bool Result, string Token)> LoginAsync(AdminDto dto)
    {
        var user = await _unitOfWork.UserRepository.SelectAsync(x => x.Email == dto.Email);
        if (user is null) throw new UserNotFoundException();

        var hasherResult = PasswordHasher.Verify(dto.Password, user.PasswordHash, user.Salt);
        if (hasherResult == false) throw new PasswordNotMatchException();

        string token = _tokenService.GenerateAdminToken(user);
        return (Result: true, Token: token);
    }

    public async Task<(bool Result, int CachedMinutes)> RegisterAsync(RegisterAdminDto dto)
    {
        var user = await _unitOfWork.UserRepository.SelectAsync(x => x.Email == dto.Email);
        if (user is not null) throw new UserAlreadyExistsException(dto.Email);

        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + dto.Email, out RegisterDto? cachedRegisterDto))
        {
            cachedRegisterDto!.FirstName = cachedRegisterDto.FirstName;
            _memoryCache.Remove(REGISTER_CACHE_KEY + dto.Email);
        }
        else _memoryCache.Set(REGISTER_CACHE_KEY + dto.Email, dto,
            TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));

        return (Result: true, CachedMinutes: CACHED_MINUTES_FOR_REGISTER);
    }

    public async Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string email)
    {
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + email, out RegisterDto? registerDto))
        {
            VerificationDto verificationDto = new VerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelper.GetDateTime();
            verificationDto.Code = CodeGenerator.GenerateRandomNumber();

            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + email, out VerificationDto? oldVerifcationDto))
            {
                _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + email);
            }

            _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + email, verificationDto,
                TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));

            EmailMessage smsMessage = new EmailMessage();
            smsMessage.Title = "ProFex";
            smsMessage.Content = "Your verification code : " + verificationDto.Code;
            smsMessage.Recipent = email.Substring(1);

            var smsResult = await _mailSender.SendAsync(smsMessage);
            if (smsResult is true) return (Result: true, CachedVerificationMinutes: CACHED_MINUTES_FOR_VERIFICATION);
            else return (Result: false, CachedVerificationMinutes: 0);
        }
        else throw new UserCacheDataExpiredException();
    }

    public async Task<(bool Result, string Token)> VerifyRegisterAsync(string email, int code)
    {
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + email, out RegisterAdminDto? registerDto))
        {
            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + email, out VerificationDto? verificationDto))
            {
                if (verificationDto!.Attempt >= VERIFICATION_MAXIMUM_ATTEMPTS)
                    throw new VerificationTooManyRequestsException();
                else if (verificationDto.Code == code)
                {
                    var dbResult = await RegisterToDatabaseAsync(registerDto!);
                    if (dbResult is true)
                    {
                        var user = await _unitOfWork.UserRepository.SelectAsync(x => x.Email == registerDto!.Email);
                        string token = _tokenService.GenerateAdminToken(user);
                        return (Result: true, Token: token);
                    }
                    else return (Result: false, Token: "");
                }
                else
                {
                    _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + email);
                    verificationDto.Attempt++;
                    _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + email, verificationDto,
                        TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));
                    return (Result: false, Token: "");
                }
            }
            else throw new VerificationCodeExpiredException();
        }
        else throw new UserCacheDataExpiredException();
    }


    private async Task<bool> RegisterToDatabaseAsync(RegisterAdminDto registerDto)
    {
        var user = new UserEntity();
        user.FirstName = registerDto.FirstName;
        user.LastName = registerDto.LastName;
        user.Email = registerDto.Email;
        user.ProfilePictureUrl = "";
        var haserResult = PasswordHasher.Hash(registerDto.Password);
        user.PasswordHash = haserResult.Hash;
        user.Salt = haserResult.Salt;
        user.CreatedAt = user.UpdatedAt = TimeHelper.GetDateTime();
        await _unitOfWork.UserRepository.AddAsync(user);

        var dbResult = await _unitOfWork.SaveAsync();
        return dbResult > 0;
    }
}
