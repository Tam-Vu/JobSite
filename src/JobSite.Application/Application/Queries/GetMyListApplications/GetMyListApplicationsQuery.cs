using JobSite.Application.Common;
using JobSite.Application.Common.Models;
namespace JobSite.Application.Application.Queries.GetMyListApplications;

public record GetMyListApplicationsQuery
(
) : IRequest<Result<List<JustApplicationDto>>>;