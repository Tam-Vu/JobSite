using JobSite.Contracts.Skill;
namespace JobSite.Contracts.Resume;
public record UpdateResumeRequest
(
    Guid Id,
    string Title,
    string Experience,
    string Education,
    string File,
    List<SkillRequest> Skills,
    List<ExperienceDetailRequest> ExperienceDetails
);