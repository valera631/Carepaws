using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Domain
{
    public class PetPhoto
    {
        public string FilePath { get; set; } = null!;
        public bool IsMainPhoto { get; set; }
    }
}
