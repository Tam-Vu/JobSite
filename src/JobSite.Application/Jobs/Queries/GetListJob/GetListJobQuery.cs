using JobSite.Application.Common.Models;
using JobSite.Application.Jobs.Common;

namespace JobSite.Application.Jobs.Queries.GetListJob;
public record GetListJobQuery() : IRequest<Result<List<JobQueryResponse>>>;