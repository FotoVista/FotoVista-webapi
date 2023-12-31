﻿using FotoVista.Service.DTOs;

namespace FotoVista.Service.Interfaces;

public interface IAuthAdminService
{
    public Task<(bool Result, int CachedMinutes)> RegisterAsync(RegisterAdminDto dto);
    public Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string email);
    public Task<(bool Result, string Token)> VerifyRegisterAsync(string email, int code);
    public Task<(bool Result, string Token)> LoginAsync(AdminDto dto);
}
