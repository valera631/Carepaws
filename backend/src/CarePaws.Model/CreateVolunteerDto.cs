using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Model
{
    public class CreateVolunteerDto
    {

        public string FullName { get; set; }

   
        public string Email { get; set; }

  
        public string Password { get; set; }

  
        public string ConfirmPassword { get; set; }

        public string Description { get; set; }

        [Range(0, 100)]
        public int YearsOfExperience { get; set; }

        public string PhoneNumber { get; set; }

        public List<SocialNetworkDto> SocialNetworks { get; set; } = new();

        public List<PaymentDetailsDto> PaymentDetails { get; set; } = new();
    }

    public class SocialNetworkDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class PaymentDetailsDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
