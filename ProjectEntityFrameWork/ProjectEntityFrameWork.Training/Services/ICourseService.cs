
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
        IList<Course> GetAllCourses(DateTime start,DateTime end);
        void CreateCourse(Course course);
        void EnrollStudents(Course course, Student student);
        (IList<Course>records,int total,int totalDisplay) GetCourses(int pageIndex, int pageSize, 
            string searchText, string sortText);
        Course GetCourse(int id);
        void Update(Course course);
        void DeleteCourse(int id);
    }
}
