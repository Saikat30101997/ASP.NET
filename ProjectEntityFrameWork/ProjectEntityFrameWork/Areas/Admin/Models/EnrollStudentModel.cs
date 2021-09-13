using ProjectEntityFrameWork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ProjectEntityFrameWork.Training.BusinessObjects;

namespace ProjectEntityFrameWork.Areas.Admin.Models
{
    public class EnrollStudentModel
    {
        public int studentId { get; set; }
        public string courseName { get; set; }
        public readonly ICourseService _courseService;
        public EnrollStudentModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public EnrollStudentModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

       //public void EnrollStudent()
       //{
       //    var courses =  _courseService.GetAllCourses();
       //    var selectcourse = courses.Where(c => c.Title == courseName).FirstOrDefault();
       //     var student = new Student
       //     {
       //         Id = studentId,
       //         DateOfBirth = DateTime.Now,
       //         Name = "Saikat"
       //     };
       //     _courseService.EnrollStudents(selectcourse,student);
       //}
    }
}
