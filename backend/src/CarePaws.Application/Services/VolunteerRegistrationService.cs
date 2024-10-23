using CarePaws.Domain.Services;
using CarePaws.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarePaws.Application.DTOs;
using CarePaws.Domain.Common;
using CarePaws.Domain.Entities;
using CarePaws.Domain.ValueObjects;

namespace CarePaws.Application.Services
{
    public class VolunteerRegistrationService
    {
        private readonly IVolunteerRepository _volunteerRepository;
        private readonly IPasswordHasher _passwordHasher;
        public VolunteerRegistrationService(
            IVolunteerRepository volunteerRepository,
            IPasswordHasher passwordHasher)
        {
            _volunteerRepository = volunteerRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<Result<Volunteer>> RegisterVolunteerAsync(CreateVolunteerDto dto)
        {
            var existingVolunteer = await _volunteerRepository.GetByEmailAsync(dto.Email);
            if (existingVolunteer != null)
            {
                return Result<Volunteer>.Failure("Email already exists");
            }

            if (dto.Password != dto.ConfirmPassword)
            {
                return Result<Volunteer>.Failure("Passwords do not match");
            }

            string passwordHash = _passwordHasher.HashPassword(dto.Password);

            var volunteerResult = Volunteer.Create(
                dto.FullName,
                dto.Email,
                passwordHash,
                dto.Description,
                dto.YearsOfExperience,
                dto.PhoneNumber
            );

            if (!volunteerResult.IsSuccess)
            {
                return Result<Volunteer>.Failure(volunteerResult.Error);
            }

            var volunteer = volunteerResult.Value;

            foreach (var network in dto.SocialNetworks)
            {
                volunteer.SocialNetworks.Add(new SocialNetwork
                {
                    Name = network.Name,
                    Url = network.Url
                });
            }

            foreach (var payment in dto.PaymentDetails)
            {
                volunteer.PaymentDetails.Add(new PaymentDetails
                {
                    Title = payment.Title,
                    Description = payment.Description
                });
            }

            await _volunteerRepository.AddAsync(volunteer);
            await _volunteerRepository.SaveChangesAsync();

            return Result<Volunteer>.Success(volunteer);
        }

    }
}
