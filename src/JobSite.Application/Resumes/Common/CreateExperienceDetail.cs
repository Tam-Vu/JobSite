namespace JobSite.Application.Resumes.Common;
public record CreateExperienceDetail
(
    string CompanyName,
    int StartYear,
    int StartMonth,
    int EndYear,
    int EndMonth,
    string Description
);