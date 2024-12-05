using JobSite.Application.Common.Models;

namespace JobSite.Application.Employers.Queries.GetListEmployers;

public record GetListEmployersQuery(

) : IRequest<Result<List<GetListEmployersResponse>>>;