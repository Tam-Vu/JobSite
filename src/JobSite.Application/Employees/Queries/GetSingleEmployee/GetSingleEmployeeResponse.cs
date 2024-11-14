namespace JobSite.Application.Employees.Queries.GetSingleEmployee;
public record GetSingleEmployeeResponse
(
    string Fullname,
    string? Address,
    AccountDto Accounts
);

public record AccountDto
(
    string Email
);
