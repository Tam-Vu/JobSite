namespace JobSite.Application.Jobs.Commands.DeleteJob;

public class DeleteJobValidator : AbstractValidator<DeleteJobCommand>
{
    public DeleteJobValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}