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
    public class EditCourseModel
    {
        private readonly ICourseService _courseService;
        public int? Id { get; set; }
        [Required,MaxLength(200)]
        public string Title { get; set; }
        [Required,Range(1000,50000,ErrorMessage ="Fees must be between 1000 and 50000")]
        public int? Fees { get; set; }
        [Required,Range(typeof(DateTime),"1/1/1971","1/1/2045")]
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
