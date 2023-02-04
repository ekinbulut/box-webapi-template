using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace box_webapi_template.Controllers;

[ApiController]
[Route("api")]
public class AuthenticationController : ControllerBase
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IClaimProvider _claimProvider;

    public AuthenticationController(IJwtProvider jwtProvider, IClaimProvider claimProvider)
    {
        _jwtProvider = jwtProvider;
        _claimProvider = claimProvider;
    }

    [HttpPost]
    [Route("token")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        // TODO: validate username and password from a DB
        if (model.Username == "testuser" && model.Password == "testpassword")
        {
            var claims = _claimProvider.CreateClaimsOf(model.Username);

            var token = _jwtProvider.CreateSecurityTokenWith(claims);
            return Ok(new
            {
                token = _jwtProvider.WriteTokenWith(token)
            });
        }

        return Unauthorized();
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}