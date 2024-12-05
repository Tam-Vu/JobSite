using JobSite.Application.Common.Models;
using JobSite.Application.Employees.Common;

namespace JobSite.Application.Employees.Commands.UpdateEmployee;

public record UpdateEmployeeCommand
(
    string Fullname,
    string Image,
    string Address,
    string PhoneNumber
) : IRequest<Result<EmployeeCommandRespose>>;