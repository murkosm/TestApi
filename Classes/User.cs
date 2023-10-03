using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Classes
{
    public class User
    {
        public  Guid id { get; set; }

        public string login { get; set; }
        public string fio { get; set; }
        public string password { get; set; }


    }

}
