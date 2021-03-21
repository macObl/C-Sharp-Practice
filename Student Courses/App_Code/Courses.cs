using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course
{
    public class Courses
    {
        public string Name = "";
        public string Number = "";

        public Courses(string x, string y)
        {
            Name = x;
            Number = y;
        }
    }
}