namespace JobSite.Application.Employees.Commands.CreateEmployee;
public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeComamnd>
{
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.Fullname)
            .NotEmpty().WithMessage("Fullname is required")
            .MaximumLength(100).WithMessage("Fullname must not exceed 100 characters");
        RuleFor(x => x.Address)
            .MaximumLength(200).WithMessage("Address must not exceed 200 characters");
    }
}