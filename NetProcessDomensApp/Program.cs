using System.Diagnostics;
using System.Net.WebSockets;
using System.Reflection;

namespace NetProcessDomensApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var process = Process.GetCurrentProcess();
            Console.WriteLine($"Id: {process.Id}");
            Console.WriteLine($"Handle: {process.Handle}");
            Console.WriteLine($"Process Name: {process.ProcessName}");

            Console.WriteLine($"Paged Memory Size: {process.PagedMemorySize64}");
            Console.WriteLine($"Virtual Memory Size: {process.VirtualMemorySize64}");
            Console.WriteLine();

            var threads = process.Threads;
            foreach (ProcessThread thread in threads)
                Console.WriteLine($"thread id: {thread.Id}");
            Console.WriteLine();

            var modules = process.Modules;
            foreach(ProcessModule module in modules)
                Console.WriteLine($"module name: {module.ModuleName}");

            //Process.Start(@"notepad.exe");
            Console.WriteLine();

            AppDomain appDomain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {appDomain.FriendlyName}");
            Console.WriteLine($"Name: {appDomain.BaseDirectory}");

            Assembly[] assemblies = appDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
                Console.WriteLine($"assembly: {assembly.GetName().Name}");
        }
    }
}
