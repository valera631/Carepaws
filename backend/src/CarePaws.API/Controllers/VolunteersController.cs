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

        public VolunteersController(VolunteerRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateVolunteerDto dto)
        {
            var result = await _registrationService.RegisterVolunteerAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(new { error = result.Error });

            return Ok(new
            {
                id = result.Value.Id,
                fullName = result.Value.FullName,
                email = result.Value.Email
            });
        }
    }

}

