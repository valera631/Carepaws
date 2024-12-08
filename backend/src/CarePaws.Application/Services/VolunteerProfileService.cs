using CarePaws.Domain.Repositories;
using CarePaws.Application.DTOs;
using CarePaws.Domain.Common;

namespace CarePaws.Application.Services
{
    public class VolunteerProfileService
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public VolunteerProfileService(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        public async Task<Result<VolunteerProfileDto>> GetVolunteerProfileAsync(string userId)
        {
            var volunteer = await _volunteerRepository.GetByIdAsync(Guid.Parse(userId));

            if (volunteer == null)
                return Result<VolunteerProfileDto>.Failure("Volunteer not found");

            var profile = new VolunteerProfileDto
            {
                Name = volunteer.FullName,
                Email = volunteer.Email,
                Bio = volunteer.Description,
                Phone = volunteer.PhoneNumber,
                Address = "123 Улица Свободы, Город, Страна" // Пример адреса
            };

            return Result<VolunteerProfileDto>.Success(profile);
        }
    }
}
