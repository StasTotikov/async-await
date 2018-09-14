using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
    }
    class Department
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            List<Department> departments = new List<Department>()
            {
                new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = "Russia", City = "Moscow" }
            };
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee()
                { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee()
                { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee()
                { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee()
                { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee()
                { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                new Employee()
                { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27,DepId = 4 }
            };

            //Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Донецке. 

   
            var tmp1 = from e in employees
                       join d in departments on e.DepId equals d.Id
                       where d.City!= "Donetsk" &&d.Country== "Ukraine"
                       select new { e.FirstName, e.LastName, d.City, d.Country };
                       

                       foreach (var item in tmp1)
            {
                Console.WriteLine(item.FirstName+" "+item.LastName+" "+item.City+" "+item.Country);
            }

            Console.WriteLine();


         
            var tmp3 = employees.Join(departments,e=>e.DepId,d=>d.Id,(e,d)=>new { e.FirstName, e.LastName, d.City, d.Country }).Where(d=>d.Country == "Ukraine"&& d.City != "Donetsk");
            foreach (var item in tmp3)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName + " " + item.City + " " + item.Country);
            }

            Console.WriteLine("--------------------------------------");
            // Вывести список стран без повторений. 
            var tmp2 = (from d in departments
                        select new { d.Country }).Distinct();
            foreach (var item in tmp2)
            {
                Console.WriteLine(item.Country);
            }

            var tmp4 = departments.Select(d => d.Country).Distinct();
            foreach (var item in tmp4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------");
            // Выбрать 3-x первых сотрудников, возраст которых превышает 25 лет.
            var tmp5 = (from e in employees
                        select new { e.FirstName,e.LastName }).Take(3);
            foreach (var item in tmp5)
            {
                Console.WriteLine(item.FirstName, item.LastName);
            }
            Console.WriteLine();
            var tmp6 = employees.Select(e => new { e.FirstName, e.LastName }).Take(3);
            foreach (var item in tmp6)
            {
                Console.WriteLine(item.FirstName, item.LastName);
            }
            Console.WriteLine("------------------------------------");

            //Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает
            //23 года

          
            var tmp7 = from e in employees
                       join d in departments on e.DepId equals d.Id
                       where d.City == "Kyiv" && e.Age>21
                       select new { e.FirstName, e.LastName,e.Age, d.City };


            foreach (var item in tmp7)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName + " "+item.Age+" " + item.City );
            }

            Console.WriteLine();

            var tmp8 = employees.Join(departments, e => e.DepId, d => d.Id, (e, d) => new { e.FirstName, e.LastName, d.City, e.Age }).Where(d => d.City == "Kyiv" ).Where(e => e.Age >21);
            foreach (var item in tmp8)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName + " " + item.Age + " " + item.City);
            }
            Console.ReadKey();

        }
    }
}
