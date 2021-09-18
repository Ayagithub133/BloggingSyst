using BloggingSystem.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.Repository
{
    public class TokenService : ITokenService
    {
        public async Task<string> BuildToken( ApplicationUser user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials =new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims:new List<Claim>()
                {   
                    new Claim("UserId",user.Id),
                },
                expires:DateTime.Now.AddDays(30),
                signingCredentials:signinCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

       

        public Task<bool> IsTokenValid()
        {
            throw new NotImplementedException();
        }
    }
}
