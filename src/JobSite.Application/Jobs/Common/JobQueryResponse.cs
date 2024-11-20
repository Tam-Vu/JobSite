namespace JobSite.Application.Jobs.Common;
public record JobQueryResponse
(
    string title,
    string description,
    string location,
    string jobType,
    Decimal salary,
    string requirement,
    string benefit
);