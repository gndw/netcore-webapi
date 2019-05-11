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
                    .SingleOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);

                if (selectedUser != null)
                {
                    Token tk = _tokenService.GenerateToken(null, DateTime.UtcNow.AddMinutes(3));                    
                    return Ok(new {
                        token = tk.StringToken,
                        expires = tk.Expires
                    });
                }
                else return NotFound(new {
                    bro = "sdf"
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

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<User>>> Users()
        // {
        //     return await _context.Users.ToListAsync();
        // }

        // [HttpGet]
        // public async Task<ActionResult<User>> Users(string id)
        // {
        //     var user = await _context.Users
        //         .AsNoTracking()
        //         .FirstOrDefaultAsync(u => u.Username == id);
            
        //     if (user == null) return NotFound();
        //     else return user; 
        // }

        // [HttpPost]
        // public async Task<ActionResult> Post( [Bind("Username,Email,Password")] User user)
        // {
        //     try
        //     {
        //         if (ModelState.IsValid)
        //         {
        //             _context.Add(user);
        //             await _context.SaveChangesAsync();
        //             return RedirectToAction(nameof(Users));
        //         }
        //     }
        //     catch (DbUpdateException)
        //     {
        //         ModelState.AddModelError("", "Unable to save changes. " +
        //             "Try again, and if the problem persists " +
        //             "see your system administrator.");
        //     }

        //     return BadRequest(ModelState);
        // }

    }
}
