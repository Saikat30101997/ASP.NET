using ProjectEntityFrameWork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ProjectEntityFrameWork.Training.BusinessObjects;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

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
        private readonly IMapper _mapper;

        public CreateCourseModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public CreateCourseModel(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        public void CreateCourse()
        {
            var course = _mapper.Map<Course>(this);

            _courseService.CreateCourse(course);
        }
    }
}
