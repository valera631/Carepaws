using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Domain
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsAdopted { get; set; }
        public bool IsUnderTreatment { get; set; }
        public string Species { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Breed { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string HealthInfo { get; set; } = null!;
        public string LocationAddress { get; set; } = null!;
        public double Weight { get; set; } 
        public double Height { get; set; } 
        public string OwnerPhoneNumber { get; set; } = null!;
        public bool IsNeutered { get; set; } 
        public DateTime BirthDate { get; set; } 
        public bool IsVaccinated { get; set; } 
        public HelpStatus Status { get; set; } 
        public List<PaymentDetails> PaymentDetails { get; set; } = new List<PaymentDetails>(); 
        public DateTime CreatedDate { get; set; } 
        
        public List<PetPhoto> Photos { get; set;} = new List<PetPhoto>();
    }
    public enum HelpStatus
    {
        NeedsHelp,
        LookingForHome,
        FoundHome
    }
}
