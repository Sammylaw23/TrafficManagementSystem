using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrafficManagementSystem.Application.DTOs.User;
using TrafficManagementSystem.Application.Interfaces.Services;
using TrafficManagementSystem.Domain.Settings;

namespace TrafficManagementSystem.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly JWTSettings _jwtsettings;
        private readonly IIdentityService _identityService;

        public UsersController(IOptions<JWTSettings> jwtsettings, IIdentityService identityService)
        {
            _jwtsettings = jwtsettings.Value;
            _identityService = identityService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(AuthenticationRequest request)
        {

            //sign token here
            var response = await _identityService.LoginAsync(request);
            return Ok(response);
        }
    }
}

//var tokenHandler = new JwtSecurityTokenHandler();
//var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
//var tokenDescriptor = new SecurityTokenDescriptor
//{
//    Subject = new ClaimsIdentity(new Claim[]
//    {
//                        new Claim(ClaimTypes.Name, request.Email)

//    }),
//    Expires = DateTime.UtcNow.AddMinutes(_jwtsettings.DurationInMinutes),
//    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//};
//var token = tokenHandler.CreateToken(tokenDescriptor);
//response.JWToken = tokenHandler.WriteToken(token);

