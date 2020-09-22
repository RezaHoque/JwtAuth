using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuth.Models;
using JwtAuth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UsersController(IAuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserInfo login)
        {
            IActionResult response = Unauthorized();
            if (login != null)
            {
                var user = _authService.AuthenticateUser(login);
                if (user != null)
                {
                    var tokenString = _authService.GenerateJwtToken(user);
                    response = Ok(new { token = tokenString });
                }
            }
            return response;
        }
    }
}
