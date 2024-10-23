public record CreateSkillCommand
(
    string Name
) : IRequest<string>;