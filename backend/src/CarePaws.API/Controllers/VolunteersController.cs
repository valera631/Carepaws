using CarePaws.Application.DTOs;
using CarePaws.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarePaws.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VolunteersController : Controller
    {
        private readonly VolunteerRegistrationService _registrationService;
        private readonly VolunteerLoginService _loginService;
        private readonly VolunteerProfileService _profileService;

        public VolunteersController(VolunteerRegistrationService registrationService, VolunteerLoginService loginService,
            VolunteerProfileService volunteerProfileService)
        {
            _registrationService = registrationService;
            _loginService = loginService;
            _profileService = volunteerProfileService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateVolunteerDto dto)
        {
            var result = await _registrationService.RegisterVolunteerAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(new { error = result.Error });

            return Ok(result.Value);
        }


       [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _loginService.LoginVolunteerAsync(dto);


            if (!result.IsSuccess)
                return BadRequest(new { error = result.Error });

            return Ok(result.Value);
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile() 
        { 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _profileService.GetVolunteerProfileAsync(userId); 
            if (!result.IsSuccess)
                return BadRequest(new { error = result.Error });

            return Ok(result.Value); }
    }

}

