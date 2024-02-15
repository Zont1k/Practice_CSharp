using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6_StudentProperties
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }

    public class StudentGrade
    {
        public double AverageNote { get; set; }
        public double MinNote { get; set; }
        public double MaxNote { get; set; }
    }
}
