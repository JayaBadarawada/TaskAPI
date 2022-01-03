using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TaskAPI.Entities;
using TaskAPI.Repositories;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public AuthController(IConfiguration configuration, IUserRepository userRepository)
        {

            _configuration = configuration;
            _userRepository = userRepository;
        }
       
        [HttpPost("register")]
        public ActionResult<User> Register(User user)
        {
            _userRepository.CreateUser(user);
            return Ok(user);
        }
        [HttpPost("login")]
        public ActionResult Login(User user)
        {
            var u = _userRepository.GetUserByNameAndPassword(user);
            if (u != null)
            {
                //if (user.Name != u.Name)
                //{
                //    return BadRequest("Name Not Found!");
                //}
                //if (user.Password != u.Password)
                //{
                //    return BadRequest("Password is wrong!");
                //}
                string Token = CreateToken(u);
                UserToken userToken = new UserToken() {UserId = u.Id, Token = Token };
                return Ok(userToken);
            }
            return NotFound("User not found!");


        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                //new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }


    }
}

