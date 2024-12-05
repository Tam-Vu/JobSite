using JobSite.Application.Common.Models;
using JobSite.Application.Employers.Queries.GetSingleEmployerResponse;

namespace JobSite.Application.Employers.Queries.GetSingleEmployer;

public record GetSingleEmployerQuery(
    Guid Id
) : IRequest<Result<GetSingleEmployereResponse>>;