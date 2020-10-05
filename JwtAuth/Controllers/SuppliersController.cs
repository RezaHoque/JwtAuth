using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
       [HttpGet]
       [Authorize]
        public IActionResult Test()
        {
            return Ok();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateProfile([FromBody] SupplierInfo model)
        {
            
                return Ok();
            
        }
    }
}
