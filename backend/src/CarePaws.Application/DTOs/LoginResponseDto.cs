using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Application.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public Guid VolunteerId { get; set; }
        public string FullName {get; set;}
    }
}
