using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees =
            {
                new Employee("CEO", "Gwyn", 66, 200f),
                new Employee("Manager", "Joe", 65, 36.1f),
                new Employee("HR", "Dana", 34, 123.36f),
                new Employee("Secretary", "Lucy", 55, 57),
                new Employee("Lead Developer", "Mike", 35, 55),
                new Employee("Intern", "El Kumi", 21, 200f),
            };

            Dictionary<int, string> myDict = new Dictionary<int, string>()
            {
                {1 , "One"},
                {2 , "Two"},
                {3 , "Three"}
            };

            Dictionary<string, Employee> employeesDictrionary = new Dictionary<string, Employee>();

            foreach (Employee emp in employees)
            {
                employeesDictrionary.Add(emp.Role, emp);
            }

            if (employeesDictrionary.ContainsKey("CEO"))
            {
                Employee empl = employeesDictrionary["CEO"];
                Console.WriteLine($"Employee Name: {empl.Name}, Role: {empl.Role}, Salary: {empl.Salary}");
            }

            //try
            //{
            //    Employee empl = employeesDictrionary["CEO"];
            //    Console.WriteLine($"Employee Name: {empl.Name}, Role: {empl.Role}, Salary: {empl.Salary}");
            //}
            //catch
            //{
            //    Console.WriteLine("No such key exists");
            //}

            Employee result = null;

            if(employeesDictrionary.TryGetValue("Intern", out result))
            {
                Console.WriteLine("Value Retrieved!");
                Console.WriteLine("Employee name: {0}", result.Name);
                Console.WriteLine("Employee role: {0}", result.Role);
                Console.WriteLine("Employee Age: {0}", result.Age);
                Console.WriteLine("Employee salary: {0}", result.Salary);
            } else
            {
                Console.WriteLine("Key doesn't exists!");
            }

            for(int i = 0; i < employeesDictrionary.Count; i++)
            {
                KeyValuePair <string, Employee> keyValPair = employeesDictrionary.ElementAt(i);

                Console.WriteLine("\nKey {0}", keyValPair.Key);

                Employee emp = keyValPair.Value;

                Console.WriteLine("Employee name: {0}", emp.Name);
                Console.WriteLine("Employee role: {0}", emp.Role);
                Console.WriteLine("Employee Age: {0}", emp.Age);
                Console.WriteLine("Employee salary: {0}", emp.Salary);
            }


            Console.ReadKey();
        }

        public class Employee
        {
            public string Role { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public float Rate { get; set; }
            public float Salary
            {
                get
                {
                    return Rate * 8 * 5 * 4 * 12;
                }
            }

            public Employee(string role, string name, int age, float rate)
            {
                this.Age = age;
                this.Role = role;
                this.Name = name;
                this.Rate = rate;
            }
        }
    }
}