using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleASPCore.Models
{
    public class Student
    { 
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
