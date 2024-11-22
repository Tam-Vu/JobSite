using JobSite.Domain.Enums;

namespace JobSite.Application.Common;
public record JustApplicationDto
(
    ApplicationStatus status,
    JobDto job
);

public record JobDto
(
    Guid id,
    string title,
    string description,
    Decimal salary,
    EmployerDto employer
);

public record EmployerDto
(
    Guid id,
    string name
);