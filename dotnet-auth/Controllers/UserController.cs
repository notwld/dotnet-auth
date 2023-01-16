using dotnet_auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dotnet_auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Admin")]
        [Authorize(Roles = "CEO")]
        public IActionResult Admin()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.Username}! You are logged in as {currentUser.Role}");
        }
        [HttpGet("Manager")]
        [Authorize(Roles = "Project Manager")]
        public IActionResult Manager()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.Username}! You are logged in as {currentUser.Role}");
        }
        [HttpGet("BA")]
        [Authorize(Roles = "Business Analyst")]
        public IActionResult BA()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.Username}! You are logged in as {currentUser.Role}");
        }
        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("ok hogaya");
        }
        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaim = identity.Claims;
                return new User
                {
                    Username = userClaim.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaim.FirstOrDefault(e => e.Type == ClaimTypes.Email)?.Value,
                    Role = userClaim.FirstOrDefault(e => e.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
