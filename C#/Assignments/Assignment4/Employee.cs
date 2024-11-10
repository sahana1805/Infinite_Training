using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class employee
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public float Salary { get; set; }

        public employee(int empid, string empname, float salary)
        {
            Empid = empid;
            Empname = empname;
            Salary = salary;
        }
    }

    class PartTimeEmployee : employee
    {
        public float Wages { get; set; }
        public PartTimeEmployee(int empid, string empname, float salary, float wages) : base(empid, empname, salary)
        {
            Wages = wages;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the details of employee");
            Console.WriteLine("Employee ID: ");
            int empid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Employee Name: ");
            string empname = Console.ReadLine();
            Console.WriteLine("Salary: ");
            float salary = float.Parse(Console.ReadLine());

            employee e = new employee(empid, empname, salary);

            Console.WriteLine("Enter details of part-time employee");
            Console.WriteLine("Employee ID: ");
            int partTimeEmpId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Employee Name: ");
            string partTimeEmpName = Console.ReadLine();
            Console.WriteLine("Salary: ");
            float partTimeSalary = float.Parse(Console.ReadLine());
            Console.WriteLine("Wages: ");
            float wages = float.Parse(Console.ReadLine());

            PartTimeEmployee pe = new PartTimeEmployee(partTimeEmpId, partTimeEmpName, partTimeSalary, wages);

            Console.WriteLine();
            Console.WriteLine("Full-time Employee Details");
            Console.WriteLine("Employee ID: " + empid);
            Console.WriteLine("Employee Name: " + empname);
            Console.WriteLine("Salary: " + salary);
            Console.WriteLine();

            Console.WriteLine("Part-time Employee Details");
            Console.WriteLine("Employee ID: " + partTimeEmpId);
            Console.WriteLine("Employee Name: " + partTimeEmpName);
            Console.WriteLine("Salary: " + partTimeSalary);
            Console.WriteLine("Wages: " + wages);


        }
    }
}
