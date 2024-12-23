using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JobSite.Application.Common.Security.Jwt;
using JobSite.Infrastructure.Common.Security.BindingEnvClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace JobSite.Infrastructure.Common.Security.Jwt;

public class TokenService : ITokenService
{
    private readonly JWTConfig _jwtConfig;
    public TokenService(JWTConfig jwtConfig)
    {
        _jwtConfig = jwtConfig;
    }
    public string GenerateAccessTokenAsync(Account account, IList<string> roles)
    {
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
            new Claim(ClaimTypes.Name, account.UserName!),
            new Claim(ClaimTypes.Email, account.Email!)
        }.Union(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _jwtConfig.Issuer,
            Audience = _jwtConfig.Audience,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.TokenExpirationInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public (string token, int validDays) GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(randomNumber);
        return (Convert.ToBase64String(randomNumber), _jwtConfig.RefreshTokenExpirationInDays);
    }

    public async Task<ClaimsIdentity> GetPrincipalFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidAudience = _jwtConfig.Audience,
            ValidIssuer = _jwtConfig.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfig.Secret)),
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var validateResult = await tokenHandler.ValidateTokenAsync(token, tokenValidationParameters);

        if (!validateResult.IsValid)
        {
            // throw new InvalidModelException(ErrorDescription.InvalidAccessOrRefreshToken);
        }
        var securityToken = validateResult.SecurityToken;
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            // throw new InvalidModelException(ErrorDescription.InvalidAccessOrRefreshToken);
        }
        return validateResult.ClaimsIdentity;
    }
}