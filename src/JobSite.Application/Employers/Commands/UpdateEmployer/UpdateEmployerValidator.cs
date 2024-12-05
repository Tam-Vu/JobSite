namespace JobSite.Application.Employers.Commands.UpdateEmployer;

public class UpdateEmployerValidator : AbstractValidator<UpdateEmployerCommand>
{
    public UpdateEmployerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Fullname is required")
            .MaximumLength(100).WithMessage("Fullname must not exceed 100 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters");

        RuleFor(x => x.Sector)
            .IsInEnum().WithMessage("Sector is not valid");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required")
            .MaximumLength(100).WithMessage("Location must not exceed 100 characters");
    }
}