using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_EstateCleanLayeredArchitecture.DTOs;
using Real_EstateCleanLayeredArchitecture.Services.Interfaces;

namespace Real_EstateCleanLayeredArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto) =>
            Ok(await _authService.RegisterAsync(dto));

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto) =>
            Ok(await _authService.LoginAsync(dto));
    }
}
