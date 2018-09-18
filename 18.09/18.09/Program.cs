using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18._09
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
                {
                    Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2
                },
                new Employee()
                {
                     Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1
                },
                new Employee()
                {
                     Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3
                },
                new Employee()
                {
                    Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2
                },
                new Employee()
                {
                    Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4
                },
                new Employee()
                {
                    Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2
                },
                new Employee()
                {
                    Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4
                }
                };

            //1) Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в
            //Украине.Выполнить запрос немедленно.
            var tmp1 = from e in employees
                       join d in departments on e.DepId equals d.Id
                       where d.Country== "Ukraine"
                       orderby e.FirstName,e.LastName
                       select new { Firstname = e.FirstName, Lastname = e.LastName, dep = d.Country };
            foreach(var item in tmp1)
            {
                Console.WriteLine($"{item.Lastname}, {item.Firstname}, {item.dep}");
            }


            var tmp2 = employees.Join(departments, d => d.DepId, e => e.Id, (d, e) => new { Firstname = d.FirstName, Lastname = d.LastName, dep = e.Country }).OrderBy(d=>d.Firstname).OrderBy(d=>d.Lastname).Where(d=>d.dep== "Ukraine").ToList();
            Console.WriteLine();
            foreach (var item in tmp2)
            {
                Console.WriteLine($"{item.Lastname}, {item.Firstname}, {item.dep}");
            }
            Console.WriteLine("----------------------------------");
            //2) Отсортировать сотрудников по возрастам, по убыванию. Вывести Id, FirstName,
            //LastName, Age.Выполнить запрос немедленно.
            var tmp3 = from e in employees
                       orderby e.Age descending
                       select new { id = e.Id, Firstname = e.FirstName, Lastname = e.LastName, age = e.Age };
            foreach (var item in tmp3)
            {
                Console.WriteLine($"{item.id}, {item.Lastname}, {item.Firstname}, {item.age}");
            }
            Console.WriteLine();
            var tmp4 = employees.OrderByDescending(e => e.Age).Select(e => new { id = e.Id, Firstname = e.FirstName, Lastname = e.LastName, age = e.Age });
            foreach (var item in tmp4)
            {
                Console.WriteLine($"{item.id}, {item.Lastname}, {item.Firstname}, {item.age}");
            }
            Console.WriteLine("---------------------------------------");
            //3) Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается
            //в списке. 
            var tmp5 = from e in employees
                       group e by e.Age
                     into g
                       select new { age = g.Key, count=g.Count() };
            foreach (var item in tmp5)
            {
                Console.WriteLine($"{item.age}, {item.count}");
            }
            Console.WriteLine();
            var tmp6 = employees.GroupBy(e => e.Age).Select(v => new { age = v.Key, count = v.Count() });
            foreach (var item in tmp6)
            {
                Console.WriteLine($"{item.age}, {item.count}");
            }
            Console.ReadKey();
        }

       
    }
}
