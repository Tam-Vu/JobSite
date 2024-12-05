using JobSite.Application.Common.Models;
using JobSite.Application.Employees.Common;

namespace JobSite.Application.Employees.Queries.GetListEmployees;

public record GetListEmployeesQuery(

) : IRequest<Result<List<EmployeeResponse>>>;
