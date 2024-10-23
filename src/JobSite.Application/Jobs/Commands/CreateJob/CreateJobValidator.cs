// namespace JobSite.Application.Jobs.Commands.CreateJob;

// public class CreateJobValidator : AbstractValidator<CreateJobCommand>
// {
//     public CreateJobValidator()
//     {
//         RuleFor(x => x.Title)
//             .NotEmpty().WithMessage("Title is required.")
//             .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

//         RuleFor(x => x.Description)
//             .NotEmpty().WithMessage("Description is required.");

//         RuleFor(x => x.Requirement)
//             .NotEmpty().WithMessage("Requirement is required.");

//         RuleFor(x => x.Benefit)
//             .NotEmpty().WithMessage("Benefit is required.");

//         RuleFor(x => x.Location)
//             .NotEmpty().WithMessage("Location is required.")
//             .MaximumLength(100).WithMessage("Location must not exceed 100 characters.");

//         RuleFor(x => x.Salary)
//             .NotEmpty().WithMessage("Salary is required.");

//         RuleFor(x => x.JobType)
//             .IsInEnum().WithMessage("Invalid JobType.");

//         // RuleFor(x => x.EmployerId)
//         //     .NotEmpty().WithMessage("EmployerId is required.");
//     }
// }