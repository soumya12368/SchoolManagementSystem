using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolManagementSystem
{
    public class SchoolDataStore
    {
        private static SchoolDataStore _instance;

        private List<Student> students;
        private List<Teacher> teachers;
        private List<Subject> subjects;

        private SchoolDataStore()
        {
            students = new List<Student>();
            teachers = new List<Teacher>();
            subjects = new List<Subject>();
        }

        public static SchoolDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SchoolDataStore();
                }
                return _instance;
            }
        }

        public List<Student> Students => students;
        public List<Teacher> Teachers => teachers;
        public List<Subject> Subjects => subjects;
    }
}
