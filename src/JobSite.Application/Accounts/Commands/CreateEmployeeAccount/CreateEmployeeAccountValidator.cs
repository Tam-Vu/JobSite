namespace JobSite.Application.Accounts.Commands.CreateEmployeeAccountCommand;

public class CreateAccountValidator : AbstractValidator<CreateEmployeeAccountCommand>
{
    public CreateAccountValidator()
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
        RuleFor(x => x.Fullname)
            .NotEmpty().WithMessage("Fullname is required")
            .MaximumLength(100).WithMessage("Fullname must not exceed 100 characters");
        RuleFor(x => x.Address)
            .MaximumLength(200).WithMessage("Address must not exceed 200 characters");
    }
}