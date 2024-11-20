using System.Security.Cryptography.X509Certificates;
using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using JobSite.Application.Jobs.Common;
using Mapster;

namespace JobSite.Application.Jobs.Queries.GetListJobOfCompany;

public class GetListJobOfCompanyHandler : IRequestHandler<GetListJobOfCompanyQuery, Result<List<JobQueryResponse>>>
{
    private readonly IJobRepository _jobRepository;
    public GetListJobOfCompanyHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }
    public async Task<Result<List<JobQueryResponse>>> Handle(GetListJobOfCompanyQuery request, CancellationToken cancellationToken)
    {
        var listJob = await _jobRepository.GetAllAsync(x => x.EmployerId == request.CompanyId, cancellationToken);
        var response = listJob.Select(job => job.Adapt<Job, JobQueryResponse>()).ToList();
        return Result<List<JobQueryResponse>>.Success(response);
    }
}
