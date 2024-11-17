using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketConcession
{
    public class TicketConcession
    {
        const double TotalFare = 500;
        public void CalculateConcession(int age)
        {
            if (age <= 5)
            {
                Console.WriteLine("Little Champs - Free Ticket");
            }
            else if (age > 60)
            {
                double discountedFare = TotalFare * 0.7;
                Console.WriteLine("Senior Citizen, Fare: " + discountedFare);
            }
            else
            {
                Console.WriteLine("Ticket Booked, Fare: " + TotalFare);
            }

        }
    }
}
