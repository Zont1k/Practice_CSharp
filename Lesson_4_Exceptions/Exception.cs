using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4_Exceptions
{
    public class UserInputException : Exception
    {
        public UserInputException(string message) : base(message) { }
    }

    public class InvalidNameException : UserInputException
    {
        public InvalidNameException(string message) : base(message) { }
    }

    public class InvalidIntException : UserInputException
    {
        public InvalidIntException(string message) : base(message) { }
    }

    public class InvalidDoubleException : UserInputException
    {
        public InvalidDoubleException(string message) : base(message) { }
    }
}
