using FotoVista.Service.DTOs;
using FotoVista.Service.Interfaces;
using FotoVista.Service.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FotoVista.WebApi.Controllers
{
    [Route("api/administrator")]
    [ApiController]
    public class AuthAdminController : ControllerBase
    {
        
        private readonly IAuthAdminService _authService;
        public AuthAdminController(IAuthAdminService authAdminService)
        {
            this._authService = authAdminService;
           
        }

        [HttpPost("register")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterAdminDto registerDto)
        {
            var validator = new RegisterValdiator();
            var result = validator.Validate(registerDto);
            if (result.IsValid)
            {
                var serviceResult = await _authService.RegisterAsync(registerDto);

                return Ok(new { serviceResult.Result, serviceResult.CachedMinutes });
            }
            else return BadRequest(result.Errors);
        }


        [HttpPost("register/send-code")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> SendCodeRegisterAsync(string email)
        {
            var result = EmailValidator.IsValid(email);
            if (result == false) return BadRequest("Phone number is invalid!");

            var serviceResult = await _authService.SendCodeForRegisterAsync(email);
            return Ok(new { serviceResult.Result, serviceResult.CachedVerificationMinutes });
        }


        [HttpPost("register/verify")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> VerifyRegisterAsync([FromBody] VerifyRegisterDto verifyRegisterDto)
        {
            var serviceResult = await _authService.VerifyRegisterAsync(verifyRegisterDto.Email, verifyRegisterDto.Code);

            return Ok(new { serviceResult.Result, serviceResult.Token });
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] AdminDto loginDto)
        {
            var validator = new LoginValidator();
            var valResult = validator.Validate(loginDto);
            if (valResult.IsValid == false) return BadRequest(valResult.Errors);
            var serviceResult = await _authService.LoginAsync(loginDto);

            return Ok(new { serviceResult.Result, serviceResult.Token });
        }
    }

}
