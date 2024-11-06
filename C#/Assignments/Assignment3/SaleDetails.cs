using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleDetails
{
    public class saledetails
    {
        private int salesno;
        private int productno;
        private double price;
        private DateTime dateofsale;
        private int quantity;
        private double totalamount;

        public saledetails(int salesno, int productno, double price, int quantity, DateTime dateofsale)
        {
            this.salesno = salesno;
            this.productno = productno;
            this.price = price;
            this.quantity = quantity;
            this.dateofsale = dateofsale;
        }

        public void Sales()
        {
            totalamount = quantity * price;
        }

        public static void showdata(saledetails sd)
        {

            Console.WriteLine("Sales Number: " + sd.salesno);
            Console.WriteLine("Product Number: " + sd.productno);
            Console.WriteLine("Price: " + sd.price);
            Console.WriteLine("Quantity: " + sd.quantity);
            Console.WriteLine("Date of Sale: " + sd.dateofsale);
            Console.WriteLine("Total Amount: " + sd.totalamount);

        }
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            saledetails sd = new saledetails(123, 8469, 2500, 2, DateTime.Now);
            sd.Sales();
            saledetails.showdata(sd);

        }
    }
}
