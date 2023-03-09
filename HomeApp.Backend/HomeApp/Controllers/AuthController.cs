using HomeApp.ApiCore.Entities.Domain;
using HomeApp.ApiCore.Entities.DTO;
using HomeApp.ApiCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeApp.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(
            [FromBody, Bind] UserDto request,
            CancellationToken ct)
        {
            try
            {
                var user = new User()
                {
                    UserName = request.Username,
                    UserEmail = request.Useremail,
                    UserPhone = request.Userphone,
                };
                var userId = await _authService.Register(user, request.Password);

                return Ok(userId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(
            [FromBody, Bind] UserBaseDto request,
            CancellationToken ct)
        {
            try
            {
                var jwtToken = await _authService.Login(request.Useremail, request.Password);
                return Ok(jwtToken);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}