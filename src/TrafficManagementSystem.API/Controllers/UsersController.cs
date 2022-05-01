using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrafficManagementSystem.Application.DTOs.User;
using TrafficManagementSystem.Domain.Settings;

namespace TrafficManagementSystem.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly JWTSettings _jwtsettings;

        public UsersController(IOptions<JWTSettings> jwtsettings)
        {
            _jwtsettings = jwtsettings.Value;
        }

        [HttpPost("login")]
        public IActionResult LoginAsync(AuthenticationRequest request)
        {
            //    //var anonymous = (() =>
            //    //{
            //    //    string Token = ""

            //    //};
            var response = new AuthenticationResponse();

            //    //sign token here
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, request.Email)

                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtsettings.DurationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            response.JWToken = tokenHandler.WriteToken(token);




            return Ok(response);
        }
    }
}

