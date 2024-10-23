using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarePaws.Domain.ValueObjects
{
    public class SocialNetwork
    {
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
    }
}
