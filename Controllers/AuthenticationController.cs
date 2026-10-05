using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCall.Managers.Interfaces;
using RentalCall.Models;
using RentalCall.Models.Dtos;
using RentalCall.Services;
using RentalCall.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace RentalCall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly JwtTokenService _jwtTokenService;
        private readonly IPasswordService _passwordService;

        public AuthenticationController(IAuthenticationManager authenticationManager, JwtTokenService jwtTokenService,
            IPasswordService passwordService)
        {
            _jwtTokenService = jwtTokenService;
            _authenticationManager = authenticationManager;
            _passwordService = passwordService;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDetailsDto loginDetailsDto)
        {
            UserModel? user = _authenticationManager.Login(loginDetailsDto);

            if (user == null)
                return Unauthorized("Invalid credentials");

            bool passwordMatch = user.Password == loginDetailsDto.Password;

            //bool passwordMatch = _passwordService.VerifyPassword(user.Password, loginDetailsDto.Password);

            if (!passwordMatch)
                return Unauthorized(new { Message = "Invalid username or password" });

            var jwtToken = _jwtTokenService.GenerateToken(user);

            //getting data from the token we use: var username = User.FindFirstValue(ClaimTypes.Name); // From token

            return Ok(new { jwtToken });
        }

        [HttpPatch("/password/reset")]
        public IActionResult Reset( LoginDetailsDto PasswordResetDto)
        {
            var PasswordHash = _passwordService.HashPassword(PasswordResetDto.Password);
            PasswordResetDto.Password = PasswordHash;

            _authenticationManager.PasswordReset(PasswordResetDto);
            return Ok("Updated");
        }

        [Authorize]
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            return Ok("PleaseRemoveTheTokenOnClientSide.");
        }
    }
}
