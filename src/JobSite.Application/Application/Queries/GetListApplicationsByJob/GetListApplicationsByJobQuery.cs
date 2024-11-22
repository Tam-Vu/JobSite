using JobSite.Application.Application.Common;
using JobSite.Application.Application.QueriesGetListApplicationsByJob;
using JobSite.Application.Common.Models;

namespace JobSite.Application.Application.Queries.GetListApplicationsByJob;
public record GetListApplicationsByJobQuery
(
    Guid id
) : IRequest<Result<List<ApplicationDto>>>;
