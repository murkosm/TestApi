using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Classes
{
    public class Temperature
    {
        public DateOnly date { get; set; }
        public int temperature { get; set; }

        public string Description { get; set; }
    }
}
