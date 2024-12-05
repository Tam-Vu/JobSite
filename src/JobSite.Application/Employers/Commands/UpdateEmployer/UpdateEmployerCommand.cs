using System.Reflection.PortableExecutable;
using JobSite.Application.Common.Models;
using JobSite.Application.Employers.Common;
using JobSite.Domain.Enums;

namespace JobSite.Application.Employers.Commands.UpdateEmployer;

public record UpdateEmployerCommand
(
    string Name,
    string Description,
    Sector Sector,
    string Location,
    string Website
) : IRequest<Result<EmployerCommandRespose>>;