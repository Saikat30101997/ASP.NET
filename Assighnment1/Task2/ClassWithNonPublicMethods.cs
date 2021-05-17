using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class ClassWithNonPublicMethods
    {
        private void PrivateMethod(string value)
        {
            Console.WriteLine(value);
        }
        protected void ProtectedMethod(string value)
        {
            Console.WriteLine(value);
        }
    }
}