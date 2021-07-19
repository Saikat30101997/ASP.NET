using ProjectEntityFrameWork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ProjectEntityFrameWork.Training.BusinessObjects;

namespace ProjectEntityFrameWork.Areas.Admin.Models
{
    public class EditCourseModel
    {
        private readonly ICourseService _courseService;
        public int? Id { get; set; }
        public string Title { get; set; }
        public int? Fees { get; set; }
        public DateTime? StartDate { get; set; }
        public EditCourseModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public EditCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void LoadModelData(int id)
        {
            var course = _courseService.GetCourse(id);
            Id = course?.Id;
            Title = course?.Title;
            Fees = course?.Fees;
            StartDate = course?.StartDate;
        }

        public void Update()
        {
            var course = new Course
            {
                Id =Id.HasValue? Id.Value : 0,
                Title = Title,
                Fees =Fees.HasValue ?  Fees.Value : 0,
                StartDate = StartDate.HasValue ? StartDate.Value : DateTime.MinValue
            };

            _courseService.Update(course);
        }
    }
}
