using dotnet_auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //initialize inject configrations to access configrations of appsettings
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous] //prevents the auth process on the point of request if there are no logs in
        [HttpPost]
       public IActionResult UserLogin([FromBody] Login login)
        {
            var user = Authentiacte(login);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }
            return NotFound("User not Found");
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])); // getting the random key that i defined in appsettings
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); // hashing alogrithm 

            var claims = new[] //dk what claims are
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authentiacte(Login login)
        {
            var currentUser = Constants.users.FirstOrDefault(
                e => e.Username.ToLower() == login.Username && e.Password == login.Password
                );
            if (currentUser != null){
                return currentUser;
            }
            return null;
        }
    }
}
