using ProjectEntityFrameWork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ProjectEntityFrameWork.Training.BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace ProjectEntityFrameWork.Areas.Admin.Models
{
    public class CreateCourseModel
    {
        [Required, MaxLength(200)]
        public string Title { get; set; }
        [Required, Range(1000, 50000, ErrorMessage = "Fees must be between 1000 and 50000")]
        public int Fees { get; set; }
        [Required, Range(typeof(DateTime), "1/1/1971", "1/1/2045")]
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

        public void CreateCourse()
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
