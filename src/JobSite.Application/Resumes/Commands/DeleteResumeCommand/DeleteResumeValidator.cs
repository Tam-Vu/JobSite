namespace JobSite.Application.Resumes.Commands;

public class DeleteResumeValidator : AbstractValidator<DeleteResumeCommand>
{
    public DeleteResumeValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}