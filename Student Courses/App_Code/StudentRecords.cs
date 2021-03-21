using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRecord
{
    public class StudentRecords
    {
        public string id = "";
        public string name = "";
        public int grade = 0;

        public StudentRecords(string x, string y, int z)
        {
            id = x;
            name = y;
            grade = z;
        }
    }
}