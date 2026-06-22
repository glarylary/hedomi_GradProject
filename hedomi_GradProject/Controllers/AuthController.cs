using hedomi.application.DTOs.UserDTOs;
using hedomi.application.Services_tharwat.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace hedomi_GradProject.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (result == null) return Unauthorized("invalid credentionals");
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDTO dto)
        {
            var (response, error) = await _authService.RegisterAsync(dto);

            if (error != null)
                return BadRequest(new { message = error });

            return Ok(response);
        }
    }
}
