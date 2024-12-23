using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetMainApp
{
    public static class Examples
    {
        public static void AssemblyLoadExample()
        {
            Assembly library = Assembly.LoadFrom("NetLibrary.dll");

            Console.WriteLine($"library name: {library.FullName}");

            Type[] types = library.GetTypes();
            foreach (Type t in types)
                Console.WriteLine(t.FullName);

            Type? typeEmployee = library.GetType("Employee");
            if (typeEmployee is not null)
            {
                var construct = typeEmployee.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null);
                var employee = construct.Invoke(null);
            }
        }
    }
}
