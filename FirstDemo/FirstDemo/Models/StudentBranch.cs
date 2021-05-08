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
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string Section { get; set; }
        public string Gender { get; set; }
        public List<Student>StudenInfo()
        {
            List<Student> listStudents = new List<Student>()
            {
               new Student() { StudentId = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
               new Student() { StudentId = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
               new Student() { StudentId = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
               new Student() { StudentId = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
               new Student() { StudentId = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
            };


            return listStudents;
        }
        public Student GetStudents(string name)
        {
          
            var res = (from st in StudenInfo() where st.Name == name select st).ToList();
           
            var std = new Student();
            foreach (var item in res)
            {
                std.StudentId = item.StudentId;
                std.Name = item.Name;
                std.Branch = item.Branch;
                std.Section = item.Section;
                std.Gender = item.Gender;
            }
            return std;
        }

     
    }

   
  
    
}
