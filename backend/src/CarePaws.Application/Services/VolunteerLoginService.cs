using CarePaws.Application.DTOs;
using CarePaws.Domain.Common;
using CarePaws.Domain.Repositories;
using CarePaws.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Application.Services
{
    public class VolunteerLoginService
    {
        private readonly IVolunteerRepository _volunteerRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly JwtService _jwtService;

        public VolunteerLoginService(IVolunteerRepository volunteerRepository, IPasswordHasher passwordHasher, JwtService jwtService)
        {
            _volunteerRepository = volunteerRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<Result<LoginResponseDto>> LoginVolunteerAsync(LoginDto dto)
        {
            var volunteer = await _volunteerRepository.GetByEmailAsync(dto.Email);
           
            if(volunteer == null)
            {
                return Result<LoginResponseDto>.Failure("Invalid email or password");
            }

            var isPasswordValid = _passwordHasher.VerifyPassword(dto.Password, volunteer.PasswordHash);
            if (!isPasswordValid)
            {
                return Result<LoginResponseDto>.Failure("Invalid email or password");
            }
            var token = _jwtService.GenerateToken(volunteer.Id, volunteer.Email);

            var response = new LoginResponseDto
            {
                Token = token,
                VolunteerId = volunteer.Id, // Используем VolunteerId
                FullName = $"{volunteer.FullName}"
            };

            return Result<LoginResponseDto>.Success(response);
        }


    }
}
