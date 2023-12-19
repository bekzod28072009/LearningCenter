using LC.Domein.Entities.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC.Service.Dto_s
{
    public class StudentDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string Password { get; set; }

        public string? Address { get; set; }

        public int Payment { get; set; }

        public string Attendance { get; set; }

        public string? ParentsPhoneNumber { get; set; }

        public Course Course { get; set; }
    }
}
