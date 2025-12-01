using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.GetByIdentifierAsync(request.PhoneNumber);
            if (user == null) return Unauthorized("Utilisateur inconnu");

            if (!_authService.VerifyPassword(user, request.Password))
                return Unauthorized("Mot de passe incorrect");

            var token = _authService.GenerateToken(user);

            return Ok(new LoginResponse
            {
                Token = token,
                HasToChangePassword = user.HasToChangePassword,
                UserId = user.Id,
                Name = user.Name
            });
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var user = await _userService.GetByIdAsync(request.UserId);
            if (user == null) return NotFound("Utilisateur introuvable");

            await _userService.SetPasswordAsync(user, request.NewPassword);
            user.HasToChangePassword = false;

            await _userService.UpdateAsync(user);
            return Ok("Mot de passe mis à jour");
        }
    }
}
