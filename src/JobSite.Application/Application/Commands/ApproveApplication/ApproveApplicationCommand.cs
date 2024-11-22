using JobSite.Application.Common.Models;

namespace JobSite.Application.Application.Commands.ApproveApplication;

public record ApproveApplicationCommand
(
    Guid Id,
    int Status
) : IRequest<Result<string>>;