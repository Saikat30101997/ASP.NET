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

        
    }

    public class StudentInfo
    {
       

        public List<Student>GetStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student(){RegNo = 1,Name = "Saikat"},
                new Student(){RegNo=2,Name="Sohel"}
            };
            return students;
        }

      
       public IList<Student>GetStudentsRes()
        {
            IList<Student> x = new List<Student>();
            var ds = new DashboardController();
             x = (from std in GetStudents() where std.Name == ds.s select std).ToList();
            return x;
        }

  
    }
}
