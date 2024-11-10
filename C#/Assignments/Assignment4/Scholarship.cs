using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class scholarship
    {
         public void Merit(double marks, double fees)
        {
            double scholarshipamount = 0;
            if (marks >= 70 && marks <= 80)
            {
                scholarshipamount = 0.2 * fees;
            }
            if (marks > 80 && marks <= 90)
            {
                scholarshipamount = 0.3 * fees;
            }
            if(marks > 90)
            {
                scholarshipamount = 0.5 * fees;
            }
            Console.WriteLine("The scholarship amount is: " + scholarshipamount);
        }
        static void Main(string[] args)
        {
            scholarship s = new scholarship();
            Console.WriteLine("Enter the marks");
            double marks = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the fees");
            double fees = Convert.ToDouble(Console.ReadLine());
            s.Merit(marks, fees);
        }
    }
}