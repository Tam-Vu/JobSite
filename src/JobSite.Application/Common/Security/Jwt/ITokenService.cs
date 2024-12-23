using System.Security.Claims;

namespace JobSite.Application.Common.Security.Jwt;

public interface ITokenService
{
    (string token, int validDays) GenerateRefreshToken();
    Task<ClaimsIdentity> GetPrincipalFromExpiredToken(string? token);
    string GenerateAccessTokenAsync(Account account, IList<string> roles);
}