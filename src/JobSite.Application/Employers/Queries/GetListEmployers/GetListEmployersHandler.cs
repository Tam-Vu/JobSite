using JobSite.Application.Common.Models;
using JobSite.Application.Employers.Common;
using JobSite.Application.IRepository;

namespace JobSite.Application.Employers.Queries.GetListEmployers;
public class GetListEmployersHandler : IRequestHandler<GetListEmployersQuery, Result<List<GetListEmployersResponse>>>
{
    private readonly IEmployerRepository _employerRepository;
    public GetListEmployersHandler(IEmployerRepository employerRepository)
    {
        _employerRepository = employerRepository;
    }
    public async Task<Result<List<GetListEmployersResponse>>> Handle(GetListEmployersQuery request, CancellationToken cancellationToken)
    {
        var employers = await _employerRepository.GetListEmployersAsync(cancellationToken);
        return Result<List<GetListEmployersResponse>>.Success(employers);
    }
}