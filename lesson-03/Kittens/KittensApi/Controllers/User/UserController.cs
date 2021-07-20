using BusinessLayer.Abstraction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittensApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromQuery] string user, string password)
        {
            string token = _userService.Authenticate(user, password);

            if (string.IsNullOrWhiteSpace(token))
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(token);
        }
    }
}
