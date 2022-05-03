using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TrafficManagementSystem.Application.DTOs.User;
using TrafficManagementSystem.Application.Exceptions;
using TrafficManagementSystem.Application.Interfaces.Services;
using TrafficManagementSystem.Application.Wrappers;
using TrafficManagementSystem.Domain.Entities.Identity;
using TrafficManagementSystem.Domain.Settings;
using TrafficManagementSystem.Infrastructure.Models;

namespace TrafficManagementSystem.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly JWTSettings _jwtsettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(IOptions<JWTSettings> jwtsettings, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _jwtsettings = jwtsettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<Response<AuthenticationResponse>> LoginAsync(AuthenticationRequest request)
        {
            var temporaryVariable = _userManager.Users.ToList();
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new ApiException("Invalid credentials.");

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            //var result = await _signInManager.CheckPasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
                throw new ApiException("Invalid credentials.");

            if (!user.EmailConfirmed)
                throw new ApiException($"Account not confirmed for '{request.Email}'.");

            //if (!user.Active)
            //    throw new ApiException("User account is inactive.");
          

            //sign token here
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

            var response = new AuthenticationResponse()
            {
                Email = user.Email,
                //DisplayName = user.DisplayName,
                JWToken = tokenHandler.WriteToken(token)
            };
            //response.JWToken = GenerateToken();



            return new Response<AuthenticationResponse>(response);
        }

        //private string GenerateToken()
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //                new Claim(ClaimTypes.Name, request.Email)

        //        }),
        //        Expires = DateTime.UtcNow.AddMinutes(_jwtsettings.DurationInMinutes),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

        //public async Task<Response<AuthenticationResponse>> LoginAsync(AuthenticationRequest request, string ipAddress)
        //{
        //    var user = await _userManager.FindByEmailAsync(request.Email);
        //    if (user == null)
        //        throw new ApiException("Invalid credentials.");

        //    if (!user.Active)
        //        throw new ApiException("User account is disabled.");

        //    var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

        //    if (!result.Succeeded)
        //        throw new ApiException("Invalid credentials.");

        //    if (!user.EmailConfirmed)
        //        throw new ApiException($"Account not confirmed for '{request.Email}'.");

        //    var refreshToken = GenerateRefreshToken(ipAddress);
        //    if (user.RefreshTokens == null) user.RefreshTokens = new List<RefreshToken>();
        //    user.RefreshTokens.Add(refreshToken);
        //    RemoveOldRefreshTokens(user);
        //    await _userManager.UpdateAsync(user);
        //    await _repositoryProvider.SaveChangesAsync();
        //    return await GenerateAuthenticationResponse(refreshToken.Token, user);
        //}


        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
