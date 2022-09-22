using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data.Entities;
using DatingApp.API.DTOs;
using DatingApp.API.Data;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthUserDto authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();
            if(_context.AppUsers.Any(u => u.Username == authUserDto.Username))
            {
                return BadRequest("Username is already taken");
            }
            using var hmac = new HMACSHA512();
            var passwordBytes = Encoding.UTF8.GetBytes(authUserDto.Password);
            var newUser = new User {
                Username = authUserDto.Username,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(passwordBytes),
                Email = authUserDto.Email
            };
            
            _context.AppUsers.Add(newUser);
            _context.SaveChanges();
            return Ok(newUser.Username);
        }
        [HttpPost("login")]
        public void Login([FromBody] string value)
        {
        }
    }
}