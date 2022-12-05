using b2a.SK.SchoolManagement;
using System;

namespace b2a.SK.LearnCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Student bharat = new Student(1,"Bharat","Mane");
            Student jitu= new Student(1, "Jitendra");
            JuniorKGStudent pari = new JuniorKGStudent(3, "Pari", "Ahir");
            pari.PrintStudentInformation();
            bharat.PrintStudentInformation();
            jitu.PrintStudentInformation();


        }
    }
    
}
