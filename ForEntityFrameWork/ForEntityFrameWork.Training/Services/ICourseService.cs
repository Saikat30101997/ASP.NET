using ForEntityFrameWork.Training.businessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.Services
{
    public interface ICourseService
    {
        IList<Course> GetAllCourses();
    }
}
