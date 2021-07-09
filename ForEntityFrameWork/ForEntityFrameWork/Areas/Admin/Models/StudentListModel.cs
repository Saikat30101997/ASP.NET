using ForEntityFrameWork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ForEntityFrameWork.Training.businessObject;

namespace ForEntityFrameWork.Areas.Admin.Models
{
    public class StudentListModel 
    {
        private readonly IStudentService _studentService;
        public IList<Student> students { get; set; }
        public StudentListModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }
        public StudentListModel(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public void GetAll()
        {
            students = _studentService.GetAllStudents();
        }
    }
}
