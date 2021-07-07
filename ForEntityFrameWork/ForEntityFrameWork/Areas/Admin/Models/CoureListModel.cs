using Autofac;
using ForEntityFrameWork.Training.businessObject;
using ForEntityFrameWork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Areas.Admin.Models
{
    public class CoureListModel
    {
        private readonly ICourseService _courseService;
        public IList<Course> Courses { get; set; }

        public CoureListModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }

        public CoureListModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void LoadModelData()
        {
            Courses = _courseService.GetAllCourses();
        }
    }
}
