namespace JobSite.Application.Accounts.Commands.VerifyAccount;

public class VerifyAccountCommandValidator : AbstractValidator<VerifyAccountCommand>
{
    public VerifyAccountCommandValidator()
    {
        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required");

        RuleFor(v => v.Token)
            .NotEmpty().WithMessage("Token is required");
    }
}