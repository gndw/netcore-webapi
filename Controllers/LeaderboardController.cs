using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWebAPI.Data;
using GWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GWebAPI.Controllers
{
    public class LeaderboardController : ControllerBase
    {
        private readonly LeaderboardContext _context;

        public LeaderboardController(LeaderboardContext context)
        {
            _context = context;
        }

        // [HttpGet]
        public async Task<ActionResult<IEnumerable<Leaderboard>>> Index()
        {
            if (_context.Leaderboards == null) return BadRequest();
            return await _context.Leaderboards.ToListAsync();
        }

    }
}
