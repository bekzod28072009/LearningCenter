using LC.Domein.Commons;
using LC.Domein.Entities.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC.Domein.Entities.Courses
{
    public class Course : Auditable
    {
        public string Name { get; set; }

        public string Payment { get; set; }

        public string Duration { get; set; }

        public string Installment_plan { get; set; }

        public Teacher Teacher { get; set; }
    }
}
