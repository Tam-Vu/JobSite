using JobSite.Application.Common.Models;

namespace JobSite.Application.Employees.Commands;

public record DeleteEmployeeCommand
(
) : IRequest<Result<string>>;