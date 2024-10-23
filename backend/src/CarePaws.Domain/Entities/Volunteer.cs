using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarePaws.Domain.Common;
using CarePaws.Domain.ValueObjects;

namespace CarePaws.Domain.Entities
{
    public class Volunteer
    {
        private Volunteer() { }


        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int YearsOfExperience { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public List<SocialNetwork> SocialNetworks { get; set; } = new List<SocialNetwork>();
        public List<PaymentDetails> PaymentDetails { get; set; } = new List<PaymentDetails>();
        public List<Pet> OwnedPets { get; set; } = new List<Pet>();


        // Добавить фабричный метод
        public static Result<Volunteer> Create(
            string fullName,
            string email,
            string passwordHash,
            string description,
            int yearsOfExperience,
            string phoneNumber)
        {
            var volunteer = new Volunteer
            {
                Id = Guid.NewGuid(),
                FullName = fullName,
                Email = email,
                PasswordHash = passwordHash,
                Description = description,
                YearsOfExperience = yearsOfExperience,
                PhoneNumber = phoneNumber
            };

            return Result<Volunteer>.Success(volunteer);
        }

        public int GetAdoptedPetsCount() => OwnedPets.Count(pet => pet.IsAdopted);
        public int GetPetsLookingForHomeCount() => OwnedPets.Count(pet => !pet.IsAdopted);
        public int GetPetsUnderTreatmentCount() => OwnedPets.Count(pet => pet.IsUnderTreatment);


    }
}
