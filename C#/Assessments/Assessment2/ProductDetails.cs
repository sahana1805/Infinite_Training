using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDetails
{
    class product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            product[] p = new product[10];
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter the details of Product " + (i + 1));
                Console.WriteLine("Enter the Product ID");
                int productid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Product Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the Product Price");
                double price = Convert.ToDouble(Console.ReadLine());
                p[i] = new product { ProductID = productid, Name = name, Price = price };
            }

            double temp = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = i+1; j < 10; j++)
                {
                    if (p[j].Price < p[i].Price)
                    {
                        temp = p[j].Price;
                        p[j].Price = p[i].Price;
                        p[i].Price = temp;
                    }
                }
                
            }

            Console.WriteLine("Sorted Output");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Product ID: " + p[i].ProductID);
                Console.Write("    Product Name: " + p[i].Name);
                Console.Write("    Price: " + p[i].Price);
                Console.WriteLine();
            }
        }
    }
}
