using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketConcession;

namespace TicketConcessionApp
{
    class Program
    {
        public const double TotalFare = 500.0;
        public string Name { get; set; }
        public int Age { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your age");
            int age = Convert.ToInt32(Console.ReadLine());

            TicketConcession.TicketConcession tc = new TicketConcession.TicketConcession();
            tc.CalculateConcession(age);
        }
    }
}
