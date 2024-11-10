using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    class doctor
    {
        private int regno;
        private string name;
        private double feescharged;

        public int Regno
        {
            get
            {
                return regno;
            }
            set
            {
                regno = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public double Feescharged
        {
            get
            {
                return feescharged;
            }
            set
            {
                feescharged = value;
            }
        }

        static void Main(string[] args)
        {
            doctor d = new doctor();
            d.Regno = 6739;
            d.Name = "Dr. Shivani";
            d.Feescharged = 500;
            Console.WriteLine("The registration number is: " + d.Regno);
            Console.WriteLine("The name of the doctor is: " + d.Name);
            Console.WriteLine("The fee charged is: " + d.Feescharged);
        }
    }
}
