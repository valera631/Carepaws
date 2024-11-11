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
        private readonly IUnitOfWork _unitOfWork;
        public VolunteerRegistrationService(
            IVolunteerRepository volunteerRepository,
            IPasswordHasher passwordHasher,
            IUnitOfWork unitOfWork)
        {
            _volunteerRepository = volunteerRepository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Volunteer>> RegisterVolunteerAsync(CreateVolunteerDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
            {
                return Result<Volunteer>.Failure("Passwords do not match");
            }

            var existingVolunteer = await _volunteerRepository.GetByEmailAsync(dto.Email);
            if (existingVolunteer != null)
            {
                return Result<Volunteer>.Failure("Email already exists");
            }

            string passwordHash = _passwordHasher.HashPassword(dto.Password);

            var volunteerResult = Volunteer.Create(
                dto.FullName,
                dto.Email,
                passwordHash,
                dto.Description,
                dto.YearsOfExperience,
                dto.PhoneNumber,
                dto.SocialNetworks.Select(network => new SocialNetwork
                {
                    Name = network.Name,
                    Url = network.Url
                }).ToList(),   // Преобразуем SocialNetworkDto в SocialNetwork
                dto.PaymentDetails.Select(payment => new PaymentDetails
                {
                    Title = payment.Title,
                    Description = payment.Description
                }).ToList()
            );

            if (!volunteerResult.IsSuccess)
            {
                return Result<Volunteer>.Failure(volunteerResult.Error);
            }

            var volunteer = volunteerResult.Value;

            await _volunteerRepository.AddAsync(volunteer);
            await _unitOfWork.SaveChangesAsync();

            return Result<Volunteer>.Success(volunteer);
        }
    }
}
