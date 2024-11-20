using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxdetails
{
    class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

        public Box(double boxLength, double boxBreadth)
        {
            Length = boxLength;
            Breadth = boxBreadth;
        }

        public Box Add(Box b)
        {
            double box3_Length = this.Length + b.Length;
            double box3_Breadth = this.Breadth + b.Breadth;
            return new Box(box3_Length, box3_Breadth);
            
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Box1 length: ");
            double length1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Box1 breadth: ");
            double breadth1 = Convert.ToDouble(Console.ReadLine());

            Box b1 = new Box(length1, breadth1);

            Console.WriteLine();
            Console.Write("Enter Box2 length: ");
            double length2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Box2 breadth: ");
            double breadth2 = Convert.ToDouble(Console.ReadLine());

            Box b2 = new Box(length2, breadth2);

            Box b3 = b1.Add(b2);

            Console.WriteLine();
            Console.WriteLine("Box3 length: " + b3.Length);
            Console.WriteLine("Box3 breadth: " + b3.Breadth);
        }
    }
}
