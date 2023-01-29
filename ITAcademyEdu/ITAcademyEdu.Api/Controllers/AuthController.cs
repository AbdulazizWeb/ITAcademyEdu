using ITAcademyEdu.Api.Models;
using ITAcademyEdu.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ITAcademyEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            string token = await _authService.LoginAsync(request.UserName, request.Password);
           
            return Ok(token);
        }
    }
}
