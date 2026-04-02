using KASHOP.BLL.Service;
using KASHOP.DAL.DTO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService) 
        { 
            _authenticationService = authenticationService;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register (RegisterRequest request)
        {
            var result = await _authenticationService.RegisterAsync(request);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authenticationService.LoginAsync(request);
            if(!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail(string token,string userId)
        {
            var isConfirm = await _authenticationService.ConfirmEmailAsync(token, userId);
            if (isConfirm) return Ok();
            return BadRequest(isConfirm);
        }
        [HttpPost("SendCode")]
        public async Task<IActionResult> RequestPasswordReset(ForgetPasswordRequest request)
        {
            var result = await _authenticationService.RequestPasswordResetAsync(request);
            if (!result.Success)
                return BadRequest(result);
            return Ok();
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult>PasswordReset(ResetPasswordRequest request)
        {
            var result = await _authenticationService.ResetPasswordAsync(request);
            if (!result.Success)
                return BadRequest(result);
            return Ok();
        }

    }
}
