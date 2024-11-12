namespace JobSite.Application.Employees.Queries.GetSingleEmployee;
public record GetSingleEmployeeResponse
(
    string Fullname,
    string? Address,
    List<AccountDto> Accounts
);

public record AccountDto
(
    string Email
);
