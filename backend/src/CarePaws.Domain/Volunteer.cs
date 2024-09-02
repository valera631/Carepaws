using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Domain
{
    public class Volunteer
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int YearsOfExperience { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public List<SocialNetwork> SocialNetworks { get; set; } = new List<SocialNetwork>();
        public List<PaymentDetails> PaymentDetails { get; set; } = new List<PaymentDetails>();
        public List<Pet> OwnedPets { get; set; } = new List<Pet>();

       
        public int GetAdoptedPetsCount()
        {
            
            return OwnedPets.Count(pet => pet.IsAdopted);
        }

      
        public int GetPetsLookingForHomeCount()
        {

            return OwnedPets.Count(pet => !pet.IsAdopted);
        }

        public int GetPetsUnderTreatmentCount()
        {
            
            return OwnedPets.Count(pet => pet.IsUnderTreatment);
        }


    }
}
