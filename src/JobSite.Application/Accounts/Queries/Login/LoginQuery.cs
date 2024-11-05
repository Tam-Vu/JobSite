
namespace JobSite.Application.Accounts.Queries.Login;
public class LoginQuery : IRequest<LoginResponse>
{
    public required string EmailOrUserName { get; set; }
    public required string Password { get; set; }
}