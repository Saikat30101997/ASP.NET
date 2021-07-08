using ForEntityFrameWork.Training.Services;
using ForEntityFrameWork.Training.businessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
namespace ForEntityFrameWork.Areas.Admin.Models
{
    public class CreateCourseModel
    {
        public string Title { get; set; }
        public int Fees { get; set; }
        public DateTime StartDate { get; set; }
        private readonly ICourseService _courseService;
        public CreateCourseModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public CreateCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public void Create()
        {
            var course = new Course
            {
                Title = Title,
                Fees = Fees,
                StartDate = StartDate
            };
            _courseService.CreateCourse(course);
        }
    }
}
