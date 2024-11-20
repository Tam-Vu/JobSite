namespace JobSite.Contracts.Job;

public record UpdateJobRequest(
    string title,
    string description,
    string requirement,
    string benefit,
    string location,
    int jobType,
    Decimal salary
);