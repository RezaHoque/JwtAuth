using JwtAuth.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public UserInfo AuthenticateUser(UserInfo model)
        {
            UserInfo user = null;
            if (model.UserName == "reza")
            {
                user = new UserInfo { UserName = model.UserName, FirstName = "Reza", LastName = "Hoque" };
            }
            return user;
        }

        public string GenerateJwtToken(UserInfo model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var nowUtc = DateTimeOffset.UtcNow;
            var expiration = nowUtc.AddMinutes(120);
            var exp = expiration.ToUnixTimeSeconds();
            var now = nowUtc.ToUnixTimeSeconds();

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              notBefore:null,
              expires: DateTime.UtcNow.AddDays(1),

              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
