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
    [Route("api/story")]
    public class StoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoryModel>>> Get()
        {
            return await _context.Stories.ToListAsync();
        }

    }
}
