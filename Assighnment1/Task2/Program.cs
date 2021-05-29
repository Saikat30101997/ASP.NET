using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassWithNonPublicMethods target = new ClassWithNonPublicMethods();
            ReflectionUtility utility = new ReflectionUtility();
            utility.CallNonPublicMethod(target, "PrivateMethod", new object[] { "This is from Private Method" });
            utility.CallNonPublicMethod(target, "ProtectedMethod", new object[] { "This is from Protected Method" });
        }
    }
}
