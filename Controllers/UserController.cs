using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GWebAPI.Data;
using GWebAPI.Error;
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
        protected readonly IGWebPasswordHashService _passwordService;
        protected readonly ILogger _logger;

        public UserController(
            ApplicationDbContext context,
            IGwebTokenService tokenService,
            IGWebPasswordHashService passwordService,
            ILogger<UserController> logger)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordService = passwordService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public virtual async Task<IActionResult> Login( [FromBody] LoginModel login)
        {
            if (!login.IsValidRequest()) {
                return BadRequest(new ErrorResponse(login.Error()));
            }

            var selectedUser = await _context.Users
                .SingleOrDefaultAsync(u => u.Username.Equals(login.Username));
            if (selectedUser == null) {
                return BadRequest(new ErrorResponse(ErrorCode.InvalidUsernameOrPassword));
            }

            string hashedPassword = _passwordService.Hash(login.Password, selectedUser.Salt);
            if (!hashedPassword.Equals(selectedUser.Password)) {
                return BadRequest(new ErrorResponse(ErrorCode.InvalidUsernameOrPassword));
            }
                
            Token tk = _tokenService.GenerateToken(
                new Claim[] { new Claim("id", selectedUser.ID.ToString()) },
                DateTime.UtcNow.AddHours(10));
            
            return Ok(new {
                token = tk.StringToken,
                expires = tk.Expires
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public virtual async Task<IActionResult> Register( [FromBody] RegisterModel register)
        {
            if (!register.IsValidRequest()) {
                return BadRequest(new ErrorResponse(register.Error()));
            }
            
            var userWithSameUsernameOrEmail = await _context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Username.Equals(register.Username) || u.Email.Equals(register.Email));

            if (userWithSameUsernameOrEmail != null) {
                if (userWithSameUsernameOrEmail.Username.Equals(register.Username))
                    return BadRequest(new ErrorResponse(ErrorCode.UsernameAlreadyTaken));
                else if (userWithSameUsernameOrEmail.Email.Equals(register.Email))
                    return BadRequest(new ErrorResponse(ErrorCode.EmailAlreadyUsed));
            }

            PasswordHash ph = _passwordService.Generate(register.Password);
            _context.Users.Add(new UserModel()
            {
                Username = register.Username,
                Email = register.Email,
                Password = ph.Password,
                Salt = ph.Salt
            });

            try { 
                await _context.SaveChangesAsync();
            }
            catch (Exception) {
                return BadRequest(new ErrorResponse(ErrorCode.RequestInternalErrorModel));
            }

            return Ok ();
        }

        [HttpGet("readtoken")]
        public ActionResult<IEnumerable<string>> ReadToken ()
        {
            try
            {
                return Ok(User.Claims.Select(c => c.Type + " : " + c.Value));   
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
