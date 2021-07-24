using AttendanceSystem.Management.BusinessObjects;
using AttendanceSystem.Management.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace AttendanceSystem.Web.Areas.Admin.Models.Students
{
    public class CreateListModel
    {
        [Required,MaxLength(300)]
        public string Name { get; set; }
        [Required,Range(11608001,11608099)]
        public int StudentRollNumber { get; set; }

        private readonly IStudentService _studentService;
        public CreateListModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }

        public CreateListModel(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public void Create()
        {
            var student = new Student
            {
                Name = Name,
                StudentRollNumber = StudentRollNumber
            };
            _studentService.CreateStudent(student);
           
        }
    }
}
