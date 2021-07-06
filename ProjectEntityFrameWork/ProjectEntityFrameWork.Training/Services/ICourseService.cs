
using ProjectEntityFrameWork.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Training.Services
{
    public interface ICourseService
    {
        IList<Course> GetAllCourses();
        void CreateCourse(Course course);
        void EnrollStudents(Course course, Student student);
    }
}
