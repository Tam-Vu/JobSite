public record SkillResponseData(
    Guid Id,
    string Name
) : IRequest<SkillResponseData>
{
    public static SkillResponseData Success(Skill skill)
    {
        return new SkillResponseData(
            skill.Id,
            skill.Name
        );
    }
}