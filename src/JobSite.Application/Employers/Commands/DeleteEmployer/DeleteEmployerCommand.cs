using JobSite.Application.Common.Models;

namespace JobSite.Application.Employers.Commands;

public record DeleteEmployerCommand
(
) : IRequest<Result<string>>;