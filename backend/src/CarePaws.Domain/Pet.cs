using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Domain
{
    public class Pet
    {
        public string Name { get; set; } = null!;
        public bool IsAdopted { get; set; }
        public bool IsUnderTreatment { get; set; }
    }
}
