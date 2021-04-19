using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api_app
{
    public class TokenService
    {
        public string Generate(string username, string password)
        {
            if(username == "admin" && password == "password")
            {
                var key = Encoding.ASCII.GetBytes("This is a *Secret* api key which I am *using* for my api");

                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]{
                        new Claim(ClaimTypes.NameIdentifier, "admin")
                    }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Expires = DateTime.Now.AddHours(2)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDesc);
                return tokenHandler.WriteToken(createdToken);
            }
            else
            {
                return null;
            }
        }
    }
}
