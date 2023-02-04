using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace box_webapi_template;

public interface IClaimProvider
{
    IEnumerable<Claim> CreateClaimsOf(string username);
}

public class ClaimProvider : IClaimProvider
{
    public IEnumerable<Claim> CreateClaimsOf(string username)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, "admin")
        };

        return claims;
    }
}