using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //1st Program
            Console.WriteLine("1st Program");
            Console.WriteLine("Enter the first number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 == num2)
                Console.WriteLine("{0} and {1} are equal", num1, num2);
            else
                Console.WriteLine("{0} and {1} are not equal", num1, num2);


            //2nd Program
            Console.WriteLine("2nd Program");
            Console.WriteLine("Enter the number");
            int num3 = Convert.ToInt32(Console.ReadLine());
            if (num3 > 0)
                Console.WriteLine($"{num3} is a positive number");
            else
                Console.WriteLine($"{num3} is a negative number");


            //3rd Program
            Console.WriteLine("3rd Program");
            Console.WriteLine("Enter the first number");
            int num4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number");
            int num5 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the operation to perfom");
            char operation = Convert.ToChar(Console.ReadLine());
            double result1 = 0;
            switch (operation)
            {
                case '+':
                    result1 = num4 + num5;
                    break;

                case '-':
                    result1 = num4 - num5;
                    break;

                case '*':
                    result1 = num4 * num5;
                    break;

                case '/':
                    result1 = num4 / num5;
                    break;

                default:
                    Console.WriteLine("Invalid Operation");
                    break;
            }
            Console.WriteLine("The result is " + result1);


            //4th Program
            Console.WriteLine("4th Program");
            Console.WriteLine("Enter the number");
            int num6 = Convert.ToInt32(Console.ReadLine());
            for(int i=0; i<=10; i++)
            {
                int result2 = num6 * i;
                Console.WriteLine(num6 + "*" + i + "=" + result2);
            }


            //5th Program
            Console.WriteLine("5th Program");
            Console.WriteLine("Enter the first number");
            int num7 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number");
            int num8 = Convert.ToInt32(Console.ReadLine());
            int result3 = num7 + num8;
            Console.WriteLine("The sum is {0}", result3);
            if(num7==num8)
            {
                int result4 = 3 * result3;
                Console.WriteLine("New Output is " + result4);
            }
        }
    }
}