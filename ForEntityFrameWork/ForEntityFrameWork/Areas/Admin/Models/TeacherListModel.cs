using ForEntityFrameWork.Training.businessObject;
using ForEntityFrameWork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace ForEntityFrameWork.Areas.Admin.Models
{
    public class TeacherListModel
    {
        private ITeacherService _teacherService;
        public IList<Teacher> Teachers { get; set; }
        public TeacherListModel()
        {
            _teacherService = Startup.AutofacContainer.Resolve<ITeacherService>();
        }
        public TeacherListModel(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public void GetAll()
        {
            Teachers = _teacherService.GetAllTeachers();
        }
    }
}
