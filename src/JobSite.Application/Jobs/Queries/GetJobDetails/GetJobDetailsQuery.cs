using JobSite.Application.Common.Models;
using JobSite.Application.Jobs.Common;

namespace JobSite.Application.Jobs.Queries.GetJobDetails;
public record GetJobDetailsQuery(Guid Id) : IRequest<Result<JobQueryResponse>>;