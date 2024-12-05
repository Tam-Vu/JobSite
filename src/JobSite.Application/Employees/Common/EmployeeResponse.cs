namespace JobSite.Application.Employees.Common;

public record EmployeeResponse
(
    Guid EmployeeId,
    Guid AccountId,
    string Fullname,
    string Address,
    string PhoneNumber,
    string Image
);