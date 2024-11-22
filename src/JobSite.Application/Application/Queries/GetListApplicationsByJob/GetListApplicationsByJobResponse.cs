
using JobSite.Domain.Enums;

namespace JobSite.Application.Application.QueriesGetListApplicationsByJob;

public record EmployeeDto
(
    string fullName,
    string image
);

public record ExperienceDetailsDto
(
    string companyName,
    string startDate,
    string endDate,
    string description
);

public record SkillDto
(
    string name
);