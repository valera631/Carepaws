using CarePaws.Application.DTOs;
using CarePaws.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarePaws.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VolunteersController : Controller
    {
        private readonly VolunteerRegistrationService _registrationService;
        private readonly VolunteerLoginService _loginService;

        public VolunteersController(VolunteerRegistrationService registrationService, VolunteerLoginService loginService)
        {
            _registrationService = registrationService;
            _loginService = loginService;
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
    }

}

