namespace JobSite.Application.Application.Commands.CreateApplication;

public class CreateApplicationValidator : AbstractValidator<CreateApplicationCommand>
{
    public CreateApplicationValidator()
    {
        RuleFor(v => v.JobId)
            .NotEmpty().WithMessage("JobId is required.");
        RuleFor(v => v.ResumeId)
            .NotEmpty().WithMessage("ResumeId is required.");
    }
}