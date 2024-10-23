using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Application.DTOs
{
    public class CreateVolunteerDto
    {

            public string FullName { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;
            public string ConfirmPassword { get; set; } = null!;
            public string Description { get; set; } = null!;
            public int YearsOfExperience { get; set; }
            public string PhoneNumber { get; set; } = null!;
            public List<SocialNetworkDto> SocialNetworks { get; set; } = new();
            public List<PaymentDetailsDto> PaymentDetails { get; set; } = new();
        

        //  социальных сетей
        public class SocialNetworkDto
        {
            public string Name { get; set; } = null!;
            public string Url { get; set; } = null!;
           
        }

        // DTO платежных данных
        public class PaymentDetailsDto
        {
            public string Title { get; set; } = null!;
            public string Description { get; set; } = null!;
        }
    }
}
