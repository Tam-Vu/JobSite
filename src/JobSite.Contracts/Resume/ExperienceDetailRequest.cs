namespace JobSite.Contracts.Resume;

public record ExperienceDetailRequest
(
    string CompanyName,
    int StartYear,
    int StartMonth,
    int EndYear,
    int EndMonth,
    string Description
);