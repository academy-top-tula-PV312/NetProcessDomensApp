using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEmplyee //NetReflectionApp
{
    public class Employee : IMovable
    {
        string name;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Age { get; set; }

        public Employee(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public Employee() : this("Anonim", 0) { }

        public void Info()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }

        public void Move()
        {
            Console.WriteLine($"Employee {Name} moved");
        }
    }

    public interface IMovable
    {
        void Move();
    }
}
