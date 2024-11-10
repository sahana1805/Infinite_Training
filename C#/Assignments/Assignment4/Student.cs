using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class student
    {
        private int rollno;
        private string name;
        private string studentclass;
        private int semester;
        private string branch;
        private int[] marks = new int[5];

        public student(int rollno, string name, string studentclass, int semester, string branch)
        {
            this.rollno = rollno;
            this.name = name;
            this.studentclass = studentclass;
            this.semester = semester;
            this.branch = branch;
        }

        public void GetMarks()
        {
            Console.WriteLine("Enter the marks for 5 subjects");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Subject" + (i + 1) + ": ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            double total = 0;
            double average = 0;
            for (int i = 0; i < 5; i++)
            {
                if (marks[i] < 35)
                {
                    Console.WriteLine("Fail");
                    return;
                }
                total += marks[i];
            }
            average = total / 5;
            if (average < 50)
            {
                Console.WriteLine("Failed");

            }
            else
            {
                Console.WriteLine("Pass");

            }
                
            
        }
        

        public void DisplayData()
        {
            Console.WriteLine("Roll Number: " + rollno);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Class: " + studentclass);
            Console.WriteLine("Semester: " + semester);
            Console.WriteLine("Branch: " + branch);
            for(int i=0;i<marks.Length;i++)
                Console.WriteLine("Mark"+ (i+1) + ": " + marks[i]);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            student stud = new student(24, "Aruna", "11th grade", 1, "Science");
            stud.GetMarks();
            stud.DisplayResult();
            Console.WriteLine();
            stud.DisplayData();
        }
    }
}
