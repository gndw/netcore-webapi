using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWebAPI.Data;
using GWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GWebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/{controller}")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                var selectedUser = await _context.Users
                    .SingleOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);

                if (selectedUser != null)
                {
                    return Ok(selectedUser);
                }
                else return NotFound();
                
            }   
            return BadRequest(ModelState);
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
