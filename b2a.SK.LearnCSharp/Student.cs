using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b2a.SK.SchoolManagement
{
    public class Student
    {

        private int id;
        private string firstName;
        private string lastName;
        protected int rollNumber;
        public Student(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public Student(int id, string firstName)
        {
            this.id = id;
            this.firstName = firstName;
        }
        public void PrintStudentInformation()
        {
            Console.WriteLine("---------------  Student Infromation ---------------");
            Console.WriteLine("Student Id: " + id);
            Console.WriteLine("Student Name: " + firstName + " " + lastName);
        }
           
    }
}
