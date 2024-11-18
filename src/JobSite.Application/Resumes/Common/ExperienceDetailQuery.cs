namespace JobSite.Application.Resumes.Common;
public record ExperienceDetailQuery
(
    string companyName,
    int startYear,
    int startMonth,
    int endYear,
    int endMonth,
    string? description
);