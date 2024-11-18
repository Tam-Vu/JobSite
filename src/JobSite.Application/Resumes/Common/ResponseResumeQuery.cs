namespace JobSite.Application.Resumes.Common;
public record ResponseResumeQuery
(
    Guid Id,
    string Title,
    string Experience,
    string Education,
    string File,
    List<SkillQuery> Skills,
    List<ExperienceDetailQuery> ExperienceDetails
);