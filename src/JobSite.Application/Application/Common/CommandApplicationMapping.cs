using JobSite.Application.Application.QueriesGetListApplicationsByJob;
using JobSite.Domain.Enums;

namespace JobSite.Application.Application.Common;

public record ApplicationDto
(
    ApplicationStatus status,
    ResumeDto resume
);

public record ResumeDto
(
    string title,
    string education,
    EmployeeDto employee,
    ICollection<ExperienceDetailsDto> experienceDetails,
    ICollection<SkillDto> skills
);