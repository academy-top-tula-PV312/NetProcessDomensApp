using NetEmplyee;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace NetReflectionApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount(2000);
            var bankAccountType = account.GetType();

            var fields = bankAccountType.GetFields(BindingFlags.Instance 
                                                    | BindingFlags.Public
                                                    | BindingFlags.NonPublic);

            foreach (var f in fields)
                Console.WriteLine($"Field: {f} {f.GetValue(account)}");

            var field = bankAccountType.GetField("amount", BindingFlags.Instance
                                                        | BindingFlags.Public
                                                        | BindingFlags.NonPublic);
            field.SetValue(account, 3000);

            Console.WriteLine(account.GetAmount());
        }
    }
}
