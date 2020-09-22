using JwtAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuth.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(UserInfo model);
        UserInfo AuthenticateUser(UserInfo model);
    }
}
