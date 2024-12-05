using JobSite.Application.Employers.Queries.GetListEmployers;
using JobSite.Application.Employers.Queries.GetSingleEmployerResponse;

namespace JobSite.Application.IRepository;

public interface IEmployerRepository : IBaseRepository<Employer>
{
    Task<List<GetListEmployersResponse>> GetListEmployersAsync(CancellationToken cancellationToken);
    Task<GetSingleEmployereResponse> GetSingleEmployerAsync(Guid id, CancellationToken cancellationToken);
}