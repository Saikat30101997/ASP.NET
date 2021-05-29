using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Task2
{
    public class ReflectionUtility
    {
        
        public void CallNonPublicMethod(object targetObject, string methodName, object[] args)
        {

            var type = Assembly.GetExecutingAssembly().GetTypes();
            var methods = (from t in type where t.Name == "ClassWithNonPublicMethods" select t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)).FirstOrDefault();
            foreach (var item in methods)
            {
                if (item.Name == methodName)
                {
                    item.Invoke(targetObject, args);
                }
            }
        }

       

    }
}
