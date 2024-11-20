
using JobSite.Application.Common.Models;
using JobSite.Application.Jobs.Common;

namespace JobSite.Application.Jobs.Queries.GetListJobOfCompany;

public record GetListJobOfCompanyQuery(
    Guid CompanyId
) : IRequest<Result<List<JobQueryResponse>>>;