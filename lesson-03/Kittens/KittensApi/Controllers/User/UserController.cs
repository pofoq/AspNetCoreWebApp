using BusinessLayer.Abstraction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> AuthenticateAsync([FromQuery] string userName, string password)
        {
            var response = await _userService.AuthenticateAsync(userName, password);

            if (response is null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            SetTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromQuery] string userName, string password)
        {
            var response = await _userService.RegisterNewUserAsync(userName, password);

            if (!response)
            {
                return BadRequest(new { message = "Registration false" });
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshAsync()
        {
            string oldRefreshToken = Request.Cookies["refreshToken"];
            string newRefreshToken = await _userService.RefreshToken(oldRefreshToken);

            if (string.IsNullOrWhiteSpace(newRefreshToken))
            {
                return Unauthorized(new { message = "Invalid token" });
            }
            SetTokenCookie(newRefreshToken);
            return Ok(newRefreshToken);
        }

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
