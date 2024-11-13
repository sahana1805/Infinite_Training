using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentgrade
{
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentID { get; set; }
        public double Grade { get; set; }
        public abstract bool IsPassed(double grade);
    }
    class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            if(grade>70)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            if(grade>80)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Undergraduate ug = new Undergraduate();
            Console.WriteLine("Enter the name");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter the student ID");
            int studentid1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the grade");
            double grade1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();


            ug.Name = name1;
            ug.StudentID = studentid1;
            ug.Grade = grade1;


            Console.WriteLine("Undergraduate Result");
            Console.WriteLine("Name: " + ug.Name);
            Console.WriteLine("Student ID: " + ug.StudentID);
            Console.WriteLine("Grade: " + ug.Grade);
            Console.WriteLine("Pass: " + ug.IsPassed(ug.Grade));
            Console.WriteLine();

            Graduate g = new Graduate();
            Console.WriteLine("Enter the name");
            string name2 = Console.ReadLine();
            Console.WriteLine("Enter the student ID");
            int studentid2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the grade");
            double grade2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();

            g.Name = name2;
            g.StudentID = studentid2;
            g.Grade = grade2;

            Console.WriteLine("Graduate Result");
            Console.WriteLine("Name: " + g.Name);
            Console.WriteLine("Student ID: " + g.StudentID);
            Console.WriteLine("Grade: " + g.Grade);
            Console.WriteLine("Pass: " + g.IsPassed(g.Grade));
        }
    }
}
