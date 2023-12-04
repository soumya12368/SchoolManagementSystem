using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public class Student : Person
    {
        public int StudentId { get; set; }
        public List<string> Subjects { get; set; }

        public Student()
        {
            Subjects = new List<string>();
        }
    }
}
