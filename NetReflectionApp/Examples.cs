using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using NetEmplyee;

namespace NetReflectionApp
{
    public static class Examples
    {
        public static void GetMembersExample()
        {
            Type typeEmployee = typeof(Employee);
            //Type typeEmployee2 = new Employee().GetType();
            //Type typeEmployee3 = Type.GetType("NetEmployee.Employee", false, true);

            Console.WriteLine($"Name: {typeEmployee.Name}");
            Console.WriteLine($"Namespace: {typeEmployee.Namespace}");
            Console.WriteLine($"Full Name: {typeEmployee.FullName}");
            Console.WriteLine($"Value type: {typeEmployee.IsValueType}");
            Console.WriteLine($"Class type: {typeEmployee.IsClass}");

            foreach (var t in typeEmployee.GetInterfaces())
                Console.WriteLine($"Interface: {t.Name}");
            Console.WriteLine();

            foreach (var t in typeEmployee.GetMembers(BindingFlags.Public
                                                      | BindingFlags.NonPublic
                                                      | BindingFlags.Instance
                                                      | BindingFlags.DeclaredOnly))
                Console.WriteLine($"Type: {t.DeclaringType}, member type: {t.MemberType}, name: {t.Name}");

            var methodInfo = typeEmployee.GetMember("Info", BindingFlags.Public | BindingFlags.Instance);
            foreach (MemberInfo m in methodInfo)
                Console.WriteLine($"Type: {m.MemberType}, Name: {m.Name}");
        }

        public static void GetMethodsExample()
        {
            Type accountType = typeof(BankAccount);

            foreach (MethodInfo method in accountType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                Console.WriteLine($"Method name: {method.Name}, return type: {method.ReturnType.Name}");
                ParameterInfo[] parameters = method.GetParameters();
                foreach (ParameterInfo param in parameters)
                {
                    string modif = "";
                    if (param.IsIn) modif += "in";
                    if (param.IsOut) modif += "out";
                    Console.WriteLine($"\t{modif} Param name: {param.Name}, type: {param.ParameterType.Name}, default: {param.DefaultValue}");
                }
            }

            BankAccount account = new BankAccount();
            var methodGet = typeof(BankAccount).GetMethod("GetAmount");

            Console.WriteLine(methodGet?.Invoke(account, null));

            var methodAdd = typeof(BankAccount).GetMethod("AddAmount");
            methodAdd?.Invoke(account, new object[] { 1000.0 });

            Console.WriteLine(methodGet?.Invoke(account, null));
        }

        public static void GetConstructorsExample()
        {
            var ctors = typeof(BankAccount).GetConstructors();
            foreach (var c in ctors)
            {
                ParameterInfo[] parameters = c.GetParameters();
                foreach (var param in parameters)

                    Console.WriteLine($"{param.ParameterType} {param.Name}");
                Console.WriteLine("-----------------");
            }

            var ctor = ctors.First();
            var acc = (BankAccount)ctor.Invoke(new object[] { 2000.0 });
            Console.WriteLine(acc.GetAmount());
        }
    }
}
