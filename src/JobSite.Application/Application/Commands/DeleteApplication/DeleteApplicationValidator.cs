namespace JobSite.Application.Application.Commands.DeleteApplication;

public class DeleteApplicationValidator : AbstractValidator<DeleteApplicationCommand>
{
    public DeleteApplicationValidator()
    {
        RuleFor(v => v.JobId)
            .NotEmpty().WithMessage("JobId is required.");
        RuleFor(v => v.ResumeId)
            .NotEmpty().WithMessage("ResumeId is required.");
    }
}