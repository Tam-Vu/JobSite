using JobSite.Application.Common.Models;
using JobSite.Application.Employers.Queries.GetListEmployers;
using JobSite.Application.Employers.Queries.GetSingleEmployer;
using JobSite.Application.IRepository;

namespace JobSite.Application.Employers.Queries.GetSingleEmployerResponse;

public class GetSingleEmployerHandler : IRequestHandler<GetSingleEmployerQuery, Result<GetSingleEmployereResponse>>
{
    private readonly IEmployerRepository _employerRepository;
    public GetSingleEmployerHandler(IEmployerRepository employerRepository)
    {
        _employerRepository = employerRepository;
    }

    public async Task<Result<GetSingleEmployereResponse>> Handle(GetSingleEmployerQuery request, CancellationToken cancellationToken)
    {
        var employer = await _employerRepository.GetSingleEmployerAsync(request.Id, cancellationToken);
        return Result<GetSingleEmployereResponse>.Success(employer);
    }
}
