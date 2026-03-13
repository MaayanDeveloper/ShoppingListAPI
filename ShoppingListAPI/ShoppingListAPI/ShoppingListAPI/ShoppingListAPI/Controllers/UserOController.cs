using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Core.DTO;
using ShoppingListAPI.Core.Models;
using ShoppingListAPI.Core.Services;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userOController : ControllerBase
    {
        private readonly IUserOService _userOService;
        private readonly IMapper _mapper;

        public userOController(IUserOService userOService, IMapper mapper)
        {
            _userOService = userOService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var user = await _userOService.GetUserByIdAsync(id);
            if (user != null)
            {
                var pro = _mapper.Map<UserDTO>(user);
                return Ok(pro);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserPostModel value)
        {
            var user = await _userOService.GetUserByIdAsync(value.Key);
            if (user != null)
            {
                return Conflict();
            }
            var e = _mapper.Map<UserO>(value);
            var s = await _userOService.RegisterUserAsync(e);
            return Ok(s);
        }

        //[HttpPost("login")]
        //public async Task<ActionResult> Login([FromBody] LoginPostModel loginData)
        //{
        //    var user = await _userOService.LoginAsync(loginData.Email, loginData.Password);
        //    if (user == null)
        //    {
        //        return Unauthorized("Incorrect email or password");
        //    }
        //    return Ok(_mapper.Map<UserDTO>(user));
        //}
    }
}
