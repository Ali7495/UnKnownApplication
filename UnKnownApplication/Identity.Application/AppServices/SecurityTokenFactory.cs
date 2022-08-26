using Identity.Application.DataTransferModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.AppServices
{
    public static class SecurityTokenFactory
    {
        public async static Task<string> SercurityTokenCreator(LoginDto loginDto)
        {
            return await Task.Run(() =>
            {
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VerifiableToken"));
                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                JwtSecurityToken tokenOptions = new JwtSecurityToken(issuer: "http://localhost",
                    claims: new List<Claim>
                    {
                    new Claim(ClaimTypes.Name,loginDto.Username),
                    new Claim(ClaimTypes.Role,"Admin")
                    },
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: signingCredentials
                    );

                string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return token;
            });
        }
    }
}
