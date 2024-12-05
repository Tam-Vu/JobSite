namespace JobSite.Application.Jobs.Commands.ChangeJobStatus;

public class ChangeJobStatusValidator : AbstractValidator<ChangeJobStatusCommand>
{
    public ChangeJobStatusValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Status)
            .InclusiveBetween(0, 1)
            .WithMessage("Status must be between 0 and 1, with 0 is active and 1 is inactive."); ;
    }
}