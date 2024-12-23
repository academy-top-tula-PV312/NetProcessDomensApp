using System.Reflection;
using System.Runtime.Loader;

namespace NetMainApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PowerWork(2, 5);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine();

            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine($"Assebly: {asm.GetName().Name}");
        }

        static void PowerWork(double x, int n)
        {
            var context = new AssemblyLoadContext(name: "NetLibrary", isCollectible: true);

            context.Unloading += ContextUnloading;

            var assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), "NetLibrary.dll");
            Assembly assemblyLibrary = context.LoadFromAssemblyPath(assemblyPath);

            var myFuncsType = assemblyLibrary.GetType("MyFuncs");

            if(myFuncsType is not null)
            {
                var powerMethod = myFuncsType.GetMethod("Power", BindingFlags.Static | BindingFlags.Public);
                var result = powerMethod.Invoke(null, new object[] { x, n });
                Console.WriteLine($"Result = {result}");
            }

            foreach(Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine($"Assebly: {asm.GetName().Name}");

            context.Unload();
        }

        static void ContextUnloading(AssemblyLoadContext context)
        {
            Console.WriteLine("NetLibrary unloading");
        }
    }
}
