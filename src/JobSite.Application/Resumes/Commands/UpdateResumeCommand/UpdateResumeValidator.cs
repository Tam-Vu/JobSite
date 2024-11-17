
namespace JobSite.Application.Resumes.Commands.UpdateResumeCommand;

using FluentValidation;
public class UpdateResumeValidator : AbstractValidator<UpdateResumeCommand>
{
    public UpdateResumeValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Experience)
            .MaximumLength(2000)
            .NotEmpty();
        RuleFor(v => v.Education)
            .MaximumLength(2000)
            .NotEmpty();
        RuleFor(v => v.File)
            .MaximumLength(200)
            .NotEmpty();
        RuleForEach(v => v.ExperienceDetails).ChildRules(w =>
        {

            w.RuleFor(x => x.CompanyName)
            .MaximumLength(200)
            .NotEmpty();

            w.RuleFor(x => x.StartYear)
                .InclusiveBetween(1900, 2100)
                .LessThanOrEqualTo(DateTime.Now.Year);

            w.RuleFor(x => x.StartMonth)
                .InclusiveBetween(1, 12);

            w.RuleFor(x => x.EndYear)
                .InclusiveBetween(1900, 2100)
                .GreaterThanOrEqualTo(x => x.StartYear)
                .LessThanOrEqualTo(DateTime.Now.Year);

            w.RuleFor(x => x.EndMonth)
                .InclusiveBetween(1, 12)
                .When(e => e.EndYear == e.StartYear && e.EndMonth <= e.StartMonth)
                .WithMessage("The time start must be less than the time end");

            w.RuleFor(x => x.Description)
                .MaximumLength(2000);
        });
    }
}