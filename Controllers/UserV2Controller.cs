using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GWebAPI.Data;
using GWebAPI.Models;
using GWebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace GWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/user")]
    public class UserV2Controller : UserController
    {
        public UserV2Controller(
            ApplicationDbContext context,
            IGwebTokenService tokenService,
            ILogger<UserV2Controller> logger
            )
        : base(context, tokenService, logger) {}

        [AllowAnonymous]
        [HttpPost("login")]
        public override async Task<IActionResult> Login( [FromBody] LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var selectedUser = await _context.Users
                    .SingleOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);

                if (selectedUser != null)
                {
                    Token tk = _tokenService.GenerateToken(null, DateTime.UtcNow.AddMinutes(3));
                    return Ok(new {
                        token = tk.StringToken,
                        expires = tk.Expires,
                        version = "2.0"
                    });
                }
                else return NotFound();
                
            }   
            return BadRequest(ModelState);
        }

    }
}
