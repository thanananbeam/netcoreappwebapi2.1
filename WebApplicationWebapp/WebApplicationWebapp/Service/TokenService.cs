using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplicationWebapp.BusinessContext.BussinessData;
using WebApplicationWebapp.Model;

namespace WebApplicationWebapp.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenToken(RespondModel resmodel) {

            var res = JsonConvert.DeserializeObject<Api_Provider>(resmodel.data.ToString());

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddSeconds(Convert.ToDouble(_configuration["Jwt:Expires"]));

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, res.username),
                new Claim(JwtRegisteredClaimNames.Email, res.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                  _configuration["Jwt:Issuer"],
                  _configuration["Jwt:Issuer"],
                  claims,
                  expires: expires,
                  signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
