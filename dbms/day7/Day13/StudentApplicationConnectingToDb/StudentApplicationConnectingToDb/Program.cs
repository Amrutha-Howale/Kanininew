using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentApplicationConnectingToDb
{
    class Program
    {

        StudentDetailsContext context;
        public Program()
        {
            context = new StudentDetailsContext();
        }
        void GetAllStudentDetailsFromDatabase()
        {
            List<Student> students = context.students.ToList();
            foreach (var item in students)
            {
                Console.WriteLine("The student details:");
                Console.WriteLine("Student id " + item.Id);
                Console.WriteLine("Student name " + item.Name);
                Console.WriteLine("Student date of joining " + item.DateofJoining);
                Console.WriteLine("---------------------------------");
            }
        }
        void AddStudents()
        {
            Student student = new Student();
            Console.WriteLine("please enter the Student name");
            student.Name = Console.ReadLine();
            Console.WriteLine("please enter the Student date of joining");
            student.DateofJoining = Convert.ToDateTime(Console.ReadLine());
            context.students.Add(student);
            context.SaveChanges();
        }
        void DeleteStudents()
        {
            Student student = new Student();
            Console.WriteLine("please enter the Student id which you want to delete");
            student.Id = Convert.ToInt32(Console.ReadLine());
            context.students.Remove(student);
            context.SaveChanges();
            //GetAllStudentDetailsFromDatabase();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.AddStudents();
            program.DeleteStudents();
            program.GetAllStudentDetailsFromDatabase();
        }
    }
}
