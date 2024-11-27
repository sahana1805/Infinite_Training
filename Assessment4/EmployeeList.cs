using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList_Assessment4
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Employee> empList = new List<Employee>
            {
                new Employee {EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", City = "Mumbai"},
                new Employee {EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", City = "Mumbai"},
                new Employee {EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", City = "Pune"},
                new Employee {EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", City = "Pune"},
                new Employee {EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", City = "Mumbai"},
                new Employee {EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", City = "Chennai"},
                new Employee {EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", City = "Mumbai"},
                new Employee {EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", City = "Chennai"},
                new Employee {EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", City = "Chennai"},
                new Employee {EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", City = "Pune"}
            };


            Console.WriteLine();
            Console.WriteLine("Details of all employees:");
            foreach (Employee emp in empList)
            {
                Console.WriteLine($"Exployee ID: {emp.EmployeeID}, First Name: {emp.FirstName}, Last Name: {emp.LastName}, Title: {emp.Title}, City: {emp.City}");
            }

            Console.WriteLine();
            Console.WriteLine("Employees not from Mumbai:");
            foreach (Employee emp in empList)
            {
                if (emp.City != "Mumbai")
                {
                    Console.WriteLine($"Exployee ID: {emp.EmployeeID}, First Name: {emp.FirstName}, Last Name: {emp.LastName}, Title: {emp.Title}, City: {emp.City}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Employees whose title is AsstManager:");
            foreach (Employee emp in empList)
            {
                if (emp.Title == "AsstManager")
                {
                    Console.WriteLine($"Exployee ID: {emp.EmployeeID}, First Name: {emp.FirstName}, Last Name: {emp.LastName}, Title: {emp.Title}, City: {emp.City}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Employees whose last name starts with S:");
            foreach (Employee emp in empList)
            {
                if (emp.LastName.StartsWith("S"))
                {
                    Console.WriteLine($"Exployee ID: {emp.EmployeeID}, First Name: {emp.FirstName}, Last Name: {emp.LastName}, Title: {emp.Title}, City: {emp.City}");
                }
            }
        }
    }
}