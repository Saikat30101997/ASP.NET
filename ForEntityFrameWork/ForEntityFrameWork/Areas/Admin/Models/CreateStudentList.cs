using ForEntityFrameWork.Training.Services;
using ForEntityFrameWork.Training.businessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace ForEntityFrameWork.Areas.Admin.Models
{
    public class CreateStudentList
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        private readonly IStudentService _studentService;
        public CreateStudentList()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }
        public CreateStudentList(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public void CreateStudent()
        {
            var Student = new Student()
            {
                Name = Name,
                DateOfBirth = DateOfBirth
            };
            _studentService.CreateStudent(Student);
        }
    }
}
