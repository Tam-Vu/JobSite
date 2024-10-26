
namespace JobSite.Application.Skills.Commands.CreateSkill;
public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
{
    public CreateSkillCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty().WithMessage("Skill name could not be empty");
    }
}