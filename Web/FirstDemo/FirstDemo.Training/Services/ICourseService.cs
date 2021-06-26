using FirstDemo.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Training.Services
{
    public interface ICourseService
    {
        IList<Course> GetAllCourses();
    }
}
