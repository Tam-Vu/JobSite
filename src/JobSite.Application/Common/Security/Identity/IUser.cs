namespace JobSite.Application.Common.Security.Identity;
public interface IUser
{
    string? Id { get; }
    string GetUserName();
}