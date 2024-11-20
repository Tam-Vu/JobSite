using FluentValidation;

namespace JobSite.Application.Jobs.Commands.UpdateJob;

public class UpdateJobValidator : AbstractValidator<UpdateJobCommand>
{
    public UpdateJobValidator()
    {
        RuleFor(x => x.title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        RuleFor(x => x.description)
            .NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.requirement)
            .NotEmpty().WithMessage("Requirement is required");
        RuleFor(x => x.benefit)
            .NotEmpty().WithMessage("Benefit is required");
        RuleFor(x => x.location)
            .NotEmpty().WithMessage("Location is required")
            .MaximumLength(100).WithMessage("Location must not exceed 100 characters.");
        RuleFor(x => x.jobType)
            .IsInEnum().WithMessage("JobType is required");
        RuleFor(x => x.salary)
            .NotEmpty().WithMessage("Salary is required");
    }
}