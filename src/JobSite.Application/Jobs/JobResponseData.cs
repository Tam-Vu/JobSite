namespace JobSite.Application.Jobs;
public record JobResponseData
(
    string Title,
    string Description,
    string Location,
    string JobType,
    string Salary
) : IRequest<JobResponseData>
{
    public static JobResponseData Success(Job job)
    {
        return new JobResponseData(
            job.Title,
            job.Description ?? string.Empty,
            job.Location ?? string.Empty,
            job.JobType.ToString(),
            job.Salary.ToString()
        );
    }
}