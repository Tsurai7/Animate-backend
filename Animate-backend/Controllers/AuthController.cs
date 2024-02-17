using Animate_backend.Dtos;
using Animate_backend.Services;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Animate_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var response = await _authService.Register(request);

            if (response == string.Empty)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var response = await _authService.Login(request);

            if (response == string.Empty)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
