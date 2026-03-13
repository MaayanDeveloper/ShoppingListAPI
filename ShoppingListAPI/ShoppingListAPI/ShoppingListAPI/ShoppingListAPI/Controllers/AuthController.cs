    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingListAPI.Core.Services;
using ShoppingListAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserOService _userService;
        public AuthController(IConfiguration configuration, IUserOService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginPostModel loginModel)
        {
            var user = await _userService.LoginAsync(loginModel.Email, loginModel.Password);
            if (user != null)
            {
                var claims = new List<Claim>()
                {
                     new Claim(ClaimTypes.Name, "malkabr"),
                     new Claim(ClaimTypes.Role, "teacher")
                };
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokeOptions = new JwtSecurityToken(
                        issuer: _configuration.GetValue<string>("JWT:Issuer"),
                        audience: _configuration.GetValue<string>("JWT:Audience"),
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(6),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new { Token = tokenString });
                }
            }
            return Unauthorized();

        }
    }
}
