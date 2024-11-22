namespace JobSite.Application.Application.Commands.ApproveApplication;

public class AcceptApplicationValidator : AbstractValidator<ApproveApplicationCommand>
{
    public AcceptApplicationValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required.");
        RuleFor(v => v.Status)
            .InclusiveBetween(0, 1)
            .WithMessage("Status must be between 0 and 1, with 0 is accept and 1 is reject.");
    }
}