
using System.Data;

namespace JobSite.Application.Accounts.Commands.CreateEmployerAccountCommand;
public class CreateEmployerAccountValidator : AbstractValidator<CreateEmployerAccountCommand>
{
    public CreateEmployerAccountValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required")
            .MaximumLength(50).WithMessage("Username must not exceed 50 characters");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must not be less than 6 characters");
        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Password and Confirm Password do not match");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^\d{10}$").WithMessage("Phone number is not valid");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Employer name is required");
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters");
        RuleFor(x => x.Sector)
            .IsInEnum().WithMessage("Sector is not valid");
        RuleFor(x => x.Location)
            .MaximumLength(200).WithMessage("Location must not exceed 200 characters");
        RuleFor(x => x.Website)
            .MaximumLength(200).WithMessage("Location must not exceed 200 characters");
    }
}