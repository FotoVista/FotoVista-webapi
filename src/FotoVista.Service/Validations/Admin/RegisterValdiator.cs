using FluentValidation;
using FotoVista.Service.DTOs;

namespace FotoVista.Service.Validations;

public class RegisterValdiator : AbstractValidator<RegisterAdminDto>
{
    public RegisterValdiator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname is required!")
            .MinimumLength(3).WithMessage("Firstname must be more than 3 characters")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");

        RuleFor(dto => dto.Email).Must(email => EmailValidator.IsValid(email))
            .WithMessage("Email is invalid! ex: example@gmail.com");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}
