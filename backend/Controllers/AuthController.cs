using backend.DTOs;
using Microsoft.AspNetCore.Http;
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
                MustChangePassword = user.MustChangePassword,
                UserId = user.Id,
                Name = user.Name
            });
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var user = await _userService.GetByIdAsync(request.UserId);
            if (user == null) return NotFound("Utilisateur introuvable");

            _authService.SetPassword(user, request.NewPassword);
            user.MustChangePassword = false;

            await _userService.UpdateAsync(user);
            return Ok("Mot de passe mis à jour");
        }
    }
