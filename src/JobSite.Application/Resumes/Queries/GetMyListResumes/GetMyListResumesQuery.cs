using JobSite.Application.Resumes.Common;

namespace JobSite.Application.Resumes.Queries.GetMyListResumes;
public record GetMyListResumesQuery : IRequest<List<ResponseResumeQuery>>;