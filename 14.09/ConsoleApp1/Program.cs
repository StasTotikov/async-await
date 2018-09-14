using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> person = new List<Person>()
        {
            new Person(){ Name = "Andrey", Age = 24, City = "Kyiv" },
            new Person(){ Name = "Liza", Age = 18, City = "Moscow" },
            new Person(){ Name = "Oleg", Age = 15, City = "London" },
            new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
            new Person(){ Name = "Sergey", Age = 32, City = "Kyiv" }
        };

            //Выбрать людей, старших 25 лет. 
            var tmp1 = from p in person where p.Age > 25 select p;
            foreach ( Person p in tmp1)
                Console.WriteLine("{0} - {1}", p.Name, p.Age);

            Console.WriteLine();
            var tmp2 = person.Where(c => c.Age>25);
            foreach (var p in tmp2)
            {
                Console.WriteLine("{0} - {1}", p.Name, p.Age);
            }
            Console.WriteLine("---------------------------------");

            // Выбрать людей, проживающих не в Киеве. 
            var tmp3 = from p in person where p.City != "Kyiv" select p;
            foreach (Person p in tmp3)
                Console.WriteLine("{0} - {1}", p.Name, p.City);

            Console.WriteLine();
            var tmp4 = person.Where(c => c.City!= "Kyiv");
            foreach (var p in tmp4)
            {
                Console.WriteLine("{0} - {1}", p.Name, p.City);
            }
            Console.WriteLine("---------------------------------");
            // Выбрать имена людей, проживающих в Киеве. 
            var tmp5 = from p in person where p.City == "Kyiv" select p;
            foreach (Person p in tmp5)
                Console.WriteLine("{0} - {1}", p.Name, p.City);

            Console.WriteLine();
            var tmp6 = person.Where(c => c.City == "Kyiv");
            foreach (var p in tmp6)
            {
                Console.WriteLine("{0} - {1}", p.Name, p.City);
            }
            Console.WriteLine("---------------------------------");
            //Выбрать людей старших 35 лет с именем Sergey. 
            var tmp7 = from p in person where p.Name == "Sergey" &&p.Age>35 select p;
            foreach (Person p in tmp7)
                Console.WriteLine("{0} - {1}", p.Name, p.Age);

            Console.WriteLine();
            var tmp8 = person.Where(c => c.Name == "Sergey"&&c.Age>35);
            foreach (var p in tmp8)
            {
                Console.WriteLine("{0} - {1}", p.Name, p.Age);
            }

            Console.WriteLine("---------------------------------");

            // Выбрать людей, проживающих в Москве. 
            var tmp9 = from p in person where p.City == "Moscow" select p;
            foreach (Person p in tmp9)
                Console.WriteLine("{0} - {1}", p.Name, p.City);

            Console.WriteLine();
            var tmp10 = person.Where(c => c.City == "Moscow");
            foreach (var p in tmp10)
            {
                Console.WriteLine("{0} - {1}", p.Name, p.City);
            }

            Console.ReadKey();
        }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
        }

      


    }
}
