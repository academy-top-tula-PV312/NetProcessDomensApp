using NetEmplyee;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace NetReflectionApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctors = typeof(BankAccount).GetConstructors();
            foreach(var c in ctors)
            {
                ParameterInfo[] parameters = c.GetParameters();
                foreach(var param in parameters)

                    Console.WriteLine($"{param.ParameterType} {param.Name}");
                Console.WriteLine("-----------------");
            }

            var ctor = ctors.First();
            var acc = (BankAccount)ctor.Invoke(new object[] { 2000.0 });
            Console.WriteLine(acc.GetAmount());    
        }
    }
}
