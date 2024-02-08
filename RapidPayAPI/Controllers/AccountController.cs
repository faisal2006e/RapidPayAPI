using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RapidPay.Database.Models;
using RapidPay.Models.Dtos;
using RapidPay.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RapidPay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService _userService;
        public AccountController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDto user)
        {
            if (user == null)
                return BadRequest("Invalid username and password");

            if (!_userService.UserVerify(user.UserName, user.Password))
            {
                return BadRequest("Invalid username and password");
            }
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
        }
    }
}
