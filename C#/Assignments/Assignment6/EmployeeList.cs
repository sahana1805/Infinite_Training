using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList
{
    class employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<employee> alist = new List<employee>();
            Console.WriteLine("Enter the number of employees");
            int empCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < empCount; i++)
            {

                Console.WriteLine("Enter the details of Employee " + (i + 1));
                Console.WriteLine("Enter the Employee ID");
                int empID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Employee Name");
                string empName = Console.ReadLine();
                Console.WriteLine("Enter the city");
                string empCity = Console.ReadLine();
                Console.WriteLine("Enter the salary");
                double empSalary = Convert.ToDouble(Console.ReadLine());

                employee emp = new employee();
                emp.EmpID = empID;
                emp.EmpName = empName;
                emp.EmpCity = empCity;
                emp.EmpSalary = empSalary;
                alist.Add(emp);
            }

            Console.WriteLine();
            Console.WriteLine("Details of all employees");
            foreach(employee emp in alist)
            {
                Console.WriteLine($"Exployee ID: {emp.EmpID}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
            }

            Console.WriteLine();
            Console.WriteLine("Employees with salary > 45000:");
            foreach (employee emp in alist)
            {
                if(emp.EmpSalary>45000)
                {
                    Console.WriteLine($"Exployee ID: {emp.EmpID}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Employees from Bangalore:");
            foreach (employee emp in alist)
            {
                if (emp.EmpCity == "bangalore" || emp.EmpCity == "Bangalore") 
                {
                    Console.WriteLine($"Exployee ID: {emp.EmpID}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
                }  
            }

            Console.WriteLine();
            alist.Sort((e1, e2) => e1.EmpName.CompareTo(e2.EmpName));
            Console.WriteLine("Employees details in ascending order:");
            foreach (employee emp in alist)
            {
                Console.WriteLine($"Exployee ID: {emp.EmpID}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
            }
        }
    }
}
