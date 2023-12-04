using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our School Data Management System!");

            // Get the number of students from the user
            int numberOfStudents = GetUserInput("Enter the number of students: ");
            // Get the number of teachers from the user
            int numberOfTeachers = GetUserInput("Enter the number of teachers: ");
            // Get the number of subjects from the user
            int numberOfSubjects = GetUserInput("Enter the number of subjects: ");

            // Filling up the lists with user input
            AddStudents(numberOfStudents);
            AddTeachers(numberOfTeachers);
            AddSubjects(numberOfSubjects);

            // Displaying lists
            DisplayStudentsInClass();
            DisplaySubjectsTaughtByTeacher();
        }

        static int GetUserInput(string prompt)
        {
            int userInput;
            do
            {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out userInput) || userInput <= 0);

            return userInput;
        }

        static void AddStudents(int count)
        {
            Console.WriteLine("\nAdding Students:");

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter student {i + 1} name: ");
                string name = Console.ReadLine();

                Console.Write($"Enter student {i + 1} class and section: ");
                string classAndSection = Console.ReadLine();

                SchoolDataStore.Instance.Students.Add(SchoolFactory.CreateStudent(name, classAndSection));
            }
        }

        static void AddTeachers(int count)
        {
            Console.WriteLine("\nAdding Teachers:");

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter teacher {i + 1} name: ");
                string name = Console.ReadLine();

                Console.Write($"Enter teacher {i + 1} class and section: ");
                string classAndSection = Console.ReadLine();

                SchoolDataStore.Instance.Teachers.Add(SchoolFactory.CreateTeacher(name, classAndSection));
            }
        }

        static void AddSubjects(int count)
        {
            Console.WriteLine("\nAdding Subjects:");

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter subject {i + 1} name: ");
                string name = Console.ReadLine();

                Console.Write($"Enter subject {i + 1} code: ");
                string subjectCode = Console.ReadLine();

                Console.Write($"Enter the teacher for subject {i + 1}: ");
                string teacherName = Console.ReadLine();

                Teacher teacher = SchoolDataStore.Instance.Teachers.Find(t => t.Name == teacherName);
                if (teacher != null)
                {
                    SchoolDataStore.Instance.Subjects.Add(SchoolFactory.CreateSubject(name, subjectCode, teacher));
                }
                else
                {
                    Console.WriteLine($"Teacher {teacherName} not found. Subject {name} will not be added.");
                }
            }
        }

        static void DisplayStudentsInClass()
        {
            Console.WriteLine("\nDisplaying Students in a Class:");

            Console.Write("Enter class and section to display students: ");
            string classAndSection = Console.ReadLine();

            var studentsInClass = SchoolDataStore.Instance.Students
                .FindAll(student => student.ClassAndSection == classAndSection);

            Console.WriteLine($"Students in Class {classAndSection}:");
            foreach (var student in studentsInClass)
            {
                Console.WriteLine($"- {student.Name}");
            }
            Console.WriteLine();
        }

        static void DisplaySubjectsTaughtByTeacher()
        {
            Console.WriteLine("\nDisplaying Subjects Taught by a Teacher:");

            Console.Write("Enter teacher name to display subjects: ");
            string teacherName = Console.ReadLine();

            var teacher = SchoolDataStore.Instance.Teachers
                .Find(t => t.Name == teacherName);

            if (teacher != null)
            {
                var subjectsTaught = SchoolDataStore.Instance.Subjects
                    .FindAll(subject => subject.Teacher == teacher);

                Console.WriteLine($"{teacherName} teaches the following subjects:");
                foreach (var subject in subjectsTaught)
                {
                    Console.WriteLine($"- {subject.Name} ({subject.SubjectCode})");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Teacher {teacherName} not found.");
            }
        }
    }
}
