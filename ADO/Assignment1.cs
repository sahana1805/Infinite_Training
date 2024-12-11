using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOAssignment1
{

    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
            };

            //Employees who have joined before 1/1/2015
            var joiningdate = empList.Where(emp => emp.DOJ < new DateTime(2015, 1, 1));
            Console.WriteLine("1.Employees who joined before 1/1/2015:");
            foreach (var emp in joiningdate)
            {
                Console.WriteLine($"First Name: {emp.FirstName}, Last Name: {emp.LastName}");
            }

            //Employees whose date of birth is after 1/1/1990
            var dob = empList.Where(emp => emp.DOB > new DateTime(1990, 1, 1));
            Console.WriteLine("\n2.Employees whose date of birth is after 1/1/1990:");
            foreach (var emp in dob)
            {
                Console.WriteLine($"First Name: {emp.FirstName}, Last Name: {emp.LastName}");
            }

            //Employees whose designation is Consultant or Associate
            var designation = empList.Where(emp => emp.Title == "Consultant" || emp.Title == "Associate");
            Console.WriteLine("\n3.Employees whose designation is Consultant or Associate:");
            foreach (var emp in designation)
            {
                Console.WriteLine($"First Name: {emp.FirstName}, Last Name: {emp.LastName}");
            }

            //Total number of employees
            int totalEmployees = empList.Count;
            Console.WriteLine($"\n4.Total number of employees: {totalEmployees}");

            //Employees belonging to Chennai
            int ChennaiEmployees = empList.Count(emp => emp.City == "Chennai");
            Console.WriteLine($"\n5.Total number of employees in Chennai: {ChennaiEmployees}");


            //Highest employee ID from the list
            var highestEmployeeID = empList.Max(emp => emp.EmployeeID);
            Console.WriteLine($"\n6.Highest employee ID: {highestEmployeeID}");

            //Employees who have joined after 1/1/2015
            var joindate = empList.Count(emp => emp.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"\n7.Total number of employees who have joined after 1/1/2015: {joindate}");

            //Employees whose designation is not "Associate"
            var NotAssociate = empList.Count(emp => emp.Title != "Associate");
            Console.WriteLine($"\n8.Total number of employees whose designation is not Associate: {NotAssociate}");

            //Total number of employees based on City
            var employeesByCity = empList.GroupBy(emp => emp.City)
                                         .Select(group => new { City = group.Key, Count = group.Count() });
            Console.WriteLine("\n9.Total number of employees based on City:");
            foreach (var cityGroup in employeesByCity)
            {
                Console.WriteLine($"{cityGroup.City}: {cityGroup.Count}");
            }


            //Total number of employees based on city and title
            var employeesByCityAndTitle = empList
                .GroupBy(emp => new { emp.City, emp.Title })
                .Select(group => new { City = group.Key.City, Title = group.Key.Title, Count = group.Count() });

            Console.WriteLine("\n10.Total number of employees based on City and Title:");
            foreach (var group in employeesByCityAndTitle)
            {
                Console.WriteLine($"{group.City} - {group.Title}: {group.Count}");
            }

            //Total number of employees who is youngest in the list
            var youngestEmployee = empList.OrderBy(emp => emp.DOB).FirstOrDefault();
            int youngestAge = DateTime.Today.Year - youngestEmployee.DOB.Year;
            Console.WriteLine($"\n11.The youngest employee is {youngestEmployee.FirstName} {youngestEmployee.LastName} with an age of {youngestAge}.");

            Console.Read();
        }
    }
}
