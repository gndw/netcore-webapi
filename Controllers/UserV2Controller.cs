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
            IGWebPasswordHashService passwordService,
            ILogger<UserV2Controller> logger
            )
        : base(context, tokenService, passwordService, logger) {}

    }
}
