using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckNumber
{
    class CheckNumberException : Exception
    {
        public CheckNumberException(string message) : base(message) { }
    }
    class checknumber
    {
        int number;
        public void getNumber()
        {
            Console.WriteLine("Enter the number");
            number = Convert.ToInt32(Console.ReadLine());
            if(number<0)
            {
                throw new CheckNumberException("Number is negative");
            }
            else
            {
                Console.WriteLine("Number is positive");
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            checknumber cn = new checknumber();
            try
            {
                cn.getNumber();
            }
            catch(CheckNumberException ce)
            {
                Console.WriteLine(ce.Message);
            }
        }
    }
}
