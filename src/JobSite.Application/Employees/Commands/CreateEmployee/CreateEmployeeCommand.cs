namespace JobSite.Application.Employees.Commands.CreateEmployee;

public record CreateEmployeeComamnd(
    string Fullname,
    string Address
) : IRequest<EmployeeCommandRespose>;