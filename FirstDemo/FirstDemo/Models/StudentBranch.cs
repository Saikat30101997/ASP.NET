using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDemo.Controllers;
using System.Reflection;
namespace FirstDemo.Models
{
    public class Student
    {
        public int RegNo { get; set; }
        public string Name { get; set; }
    
        public List<Student>StudenInfo()
        {
            List<Student> sd = new List<Student>();
            sd.Add(new Student() { Name = "Saikat", RegNo = 1 });
            sd.Add(new Student() { Name = "Sohel", RegNo = 2 });

            return sd;
        }
        public Student GetStudents(string name)
        {
          
            var res = (from st in StudenInfo() where st.Name == name select st).ToList();
           
            var std = new Student();
            foreach (var item in res)
            {
                std.Name = item.Name;
                std.RegNo = item.RegNo;
            }
            return std;
        }

     
    }

   
  
    
}
