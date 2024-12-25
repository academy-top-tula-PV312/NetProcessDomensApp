using System.Dynamic;

namespace NetDynamicLanguageRuntimeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic bob = new EmployeeObject();
            bob.Name = "Bobby";
            bob.Age = 40;

            bob.Info = (Action)(() => Console.WriteLine($"{bob.Name} {bob.Age}"));
            bob.AddAge = (Action<int>)((diff) => bob.Age += diff);

            bob.Info();

            bob.AddAge(5);
            bob.Info();
        }
    }

    class EmployeeObject : DynamicObject
    {
        Dictionary<string, object> props = new();

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            if(value is not null)
            {
                props[binder.Name] = value;
                return true;
            }
            return false;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            result = null;
            if(props.ContainsKey(binder.Name))
            {
                result = props[binder.Name];
                return true;
            }
            return false;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            result = null;
            if(props.ContainsKey(binder.Name))
            {
                dynamic method = props[binder.Name];
                if (method.GetType() == typeof(Action))
                    method();
                if (method.GetType() == typeof(Action<int>))
                    method((int)args[0]);
                return true;
            }
            return false;
        }
    }

}
