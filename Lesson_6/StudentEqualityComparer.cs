using Lesson_6_StudentProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6_StudentEqualityComparer
{
    // Custom equality comparer for Student class
    class StudentNameComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x == null || y == null)
                return false;

            return x.FirstName == y.FirstName && x.LastName == y.LastName;
        }

        public int GetHashCode(Student obj)
        {
            if (obj == null)
                return 0;

            return HashCode.Combine(obj.FirstName, obj.LastName);
        }
    }
}
