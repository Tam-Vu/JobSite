using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using JobSite.Application.Jobs.Common;
using Mapster;

namespace JobSite.Application.Jobs.Queries.GetJobDetails;

public class GetJobDetailsHandler : IRequestHandler<GetJobDetailsQuery, Result<JobQueryResponse>>
{
    private readonly IJobRepository _jobRepository;
    public GetJobDetailsHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<Result<JobQueryResponse>> Handle(GetJobDetailsQuery request, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.GetByIdAsync(request.Id, cancellationToken);
        var response = job.Adapt<Job, JobQueryResponse>();
        return Result<JobQueryResponse>.Success(response);
    }
}