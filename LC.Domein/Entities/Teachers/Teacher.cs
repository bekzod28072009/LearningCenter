using LC.Domein.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC.Domein.Entities.Teachers
{
    public class Teacher : Auditable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string? Experiance { get; set; }

        public string Salary { get; set; }
    }
}
