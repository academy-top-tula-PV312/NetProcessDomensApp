using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDynamicLanguageRuntimeApp
{
    public static class Examples
    {
        public static void DynamicExample()
        {
            object obj;
            obj = 100;
            Console.WriteLine((int)obj + 200);

            obj = "Hello";
            Console.WriteLine(String.Compare(obj as string, "Hello"));


            dynamic dyn;

            dyn = 100;
            Console.WriteLine(dyn + 200);

            dyn = "Hello";
            Console.WriteLine(String.Compare(dyn, "Hello"));

            var n = 100;
        }

        public static void ExpanoObjectExample()
        {
            dynamic user = new ExpandoObject();
            user.LastName = "Smith";
            user.Age = 30;
            user.Skills = new List<string> { "C++", "C#", "JavaScript" };

            user.Info = (Action)(() => Console.WriteLine($"{user.LastName} {user.Age}"));
            user.Info();

            user.AddAge = (Action<int>)((diff) => user.Age += diff);
            user.AddAge(5);
            user.Info();
        }
    }
}
