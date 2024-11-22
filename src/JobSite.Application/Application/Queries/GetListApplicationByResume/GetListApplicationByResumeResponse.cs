namespace JobSite.Application.Application.Queries.GetListApplicationByResume;

using JobSite.Application.Common;
using JobSite.Domain.Enums;

public record GetListApplicationByResumeResponse
(
    string title,
    ICollection<JustApplicationDto> applications
);