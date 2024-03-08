using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    class Element<T>
    {
        public T Data { get; set; }
        public Element<T> Next { get; set; }

        public Element(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
