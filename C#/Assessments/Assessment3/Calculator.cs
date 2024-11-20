using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Calculator
    {
        delegate int calculatordelegate(int num1, int num2);
        static void Main(string[] args)
        {
            calculatordelegate Addition = addition;
            calculatordelegate Subtraction = subtraction;
            calculatordelegate Multiplication = multiplication;

            Console.Write("Enter Number 1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number 2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Addition: " + Addition(num1, num2));
            Console.WriteLine();

            Console.Write("Subtraction: " + Subtraction(num1, num2));
            Console.WriteLine();

            Console.Write("Multiplication: " + Multiplication(num1, num2));
            Console.WriteLine();
        }

        static int addition(int num1, int num2)
        {
            return num1 + num2;
        }
        static int subtraction(int num1, int num2)
        {
            return num1 - num2;
        }
        static int multiplication(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}
