using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Application.DTOs
{
    public class VolunteerResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int YearsOfExperience { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public List<SocialNetworkDto> SocialNetworks { get; set; } = new();
        public List<PaymentDetailsDto> PaymentDetails { get; set; } = new();

        public class SocialNetworkDto
        {
            public string Name { get; set; } = null!;
            public string Url { get; set; } = null!;
        }

        public class PaymentDetailsDto
        {
            public string Title { get; set; } = null!;
            public string Description { get; set; } = null!;
        }
    }
}
