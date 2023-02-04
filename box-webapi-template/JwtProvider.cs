using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace box_webapi_template;

public interface IJwtProvider
{
    JwtSecurityToken CreateSecurityTokenWith(IEnumerable<Claim> claims);
    string WriteTokenWith(JwtSecurityToken token);
}

/*
 * @author: Ekin Bulut
 * @date  : 04.02.2023
 * 
 * TODO : implement secrets manager to get issuer, audience and security key.
 */
public class JwtProvider : IJwtProvider
{
    public JwtSecurityToken CreateSecurityTokenWith(IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken
        (
            issuer: "localhost:5279", // get from secrets
            audience: "localhost:5279",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yoursecretkeyyoursecretkeyyoursecretkeyyoursecretkeyyoursecretkey")), 
                SecurityAlgorithms.HmacSha256)
        );

        return token;
    }

    public string WriteTokenWith(JwtSecurityToken token)
    {
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}