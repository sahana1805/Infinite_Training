using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList alist = new ArrayList();
            Console.WriteLine("Enter the numbers separated by spaces");
            string value = Console.ReadLine();
            string[] inputValues = value.Split(' ');

            foreach(var num in inputValues)
            {
                int number = Convert.ToInt32(num);
                alist.Add(number);
            }

            foreach(int num in alist)
            {
                int square = num * num;
                if(square > 20)
                {
                    Console.WriteLine("Number: " + num + ", " + "Square: " + square);
                }
            }
        }
    }
}
