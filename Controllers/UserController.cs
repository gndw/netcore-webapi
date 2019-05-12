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
    [ApiVersion("1.0")]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IGwebTokenService _tokenService;
        protected readonly ILogger _logger;

        public UserController(
            ApplicationDbContext context,
            IGwebTokenService tokenService,
            ILogger<UserController> logger)
        {
            _context = context;
            _tokenService = tokenService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public virtual async Task<IActionResult> Login( [FromBody] LoginModel login)
        {
            ValidationModel requestValidation = login.Validate();
            if (requestValidation.IsValid)
            {
                var selectedUser = await _context.Users
                    .SingleOrDefaultAsync(u => u.Username.Equals(login.Username) && u.Password.Equals(login.Password));

                if (selectedUser != null)
                {
                    Token tk = _tokenService.GenerateToken(null, DateTime.UtcNow.AddHours(10));                    
                    return Ok(new {
                        token = tk.StringToken,
                        expires = tk.Expires
                    });
                }
                else return NotFound(ErrorBuilder.Create(ErrorCode.InvalidUsernameOrPassword));
                
            }
            else
            {
                return BadRequest(ErrorBuilder.Create(requestValidation));
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public virtual async Task<IActionResult> Register( [FromBody] RegisterModel register)
        {
            ValidationModel requestValidation = register.Validate();
            if (requestValidation.IsValid)
            {
                var userWithSameUsernameOrEmail = await _context.Users
                    .AsNoTracking()
                    .SingleOrDefaultAsync(u => u.Username.Equals(register.Username) || u.Email.Equals(register.Email));

                if (userWithSameUsernameOrEmail != null) {
                    if (userWithSameUsernameOrEmail.Username.Equals(register.Username))
                        return BadRequest(ErrorBuilder.Create(ErrorCode.UsernameAlreadyTaken));
                    else if (userWithSameUsernameOrEmail.Email.Equals(register.Email))
                        return BadRequest(ErrorBuilder.Create(ErrorCode.EmailAlreadyUsed));
                }

                UserModel newUser = new UserModel()
                {
                    Username = register.Username,
                    Email = register.Email,
                    Password = register.Password
                };

                _context.Users.Add(newUser);

                try
                { 
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest(ErrorBuilder.Create(ErrorCode.RequestInternalError,"Contact your Administrator"));
                }

                return Ok (new {
                    id = newUser.ID,
                    username = newUser.Username,
                    email = newUser.Email
                });
            }
            else
            {
                return BadRequest(ErrorBuilder.Create(requestValidation));
            }
        }

        [HttpGet("readtoken")]
        public ActionResult<IEnumerable<string>> ReadToken ()
        {
            try
            {
                var claim = User.Claims.First(c => c.Type == ClaimTypes.Name);
                return Ok(claim.Type + " :: " + claim.Value);   
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
