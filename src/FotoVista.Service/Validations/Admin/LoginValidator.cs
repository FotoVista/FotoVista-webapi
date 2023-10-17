using FluentValidation;
using FotoVista.Service.DTOs;

namespace FotoVista.Service.Validations;

public class LoginValidator : AbstractValidator<AdminDto>
{
    public LoginValidator()
    {
        RuleFor(dto => dto.Email).Must(email => EmailValidator.IsValid(email))
            .WithMessage("Email is invalid! ex: example@gmail.com");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}
