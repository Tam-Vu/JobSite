
using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using JobSite.Application.Jobs.Common;
using JobSite.Application.Jobs.Queries.GetListJob;
using Mapster;
using Microsoft.VisualBasic;

namespace JobSite.Application.Jobs.Queries;

public class GetListJobHandler : IRequestHandler<GetListJobQuery, Result<List<JobQueryResponse>>>
{
    private readonly IJobRepository _jobRepository;
    public GetListJobHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<Result<List<JobQueryResponse>>> Handle(GetListJobQuery request, CancellationToken cancellationToken)
    {
        var listJob = await _jobRepository.GetAllAsync(cancellationToken);
        var response = listJob.Select(job => job.Adapt<Job, JobQueryResponse>()).ToList();
        return Result<List<JobQueryResponse>>.Success(response);
    }
}