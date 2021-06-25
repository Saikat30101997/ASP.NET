using ForeEntityFrameWork.Training.Context;
using ForEntityFrameWork.Training.businessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.Services
{
    public class CourseService : ICourseService
    {
        private readonly TrainingDbContext _trainingDbContext;
        public CourseService(TrainingDbContext trainingContext)
        {
            _trainingDbContext = trainingContext;
        }
      
        public IList<Course> GetAllCourses()
        {
            var courseList = _trainingDbContext.Courses.ToList();
            var courses =new List<Course>();
            foreach (var entites in courseList)
            {
                var course = new Course()
                {
                    Title = entites.Title,
                    Fees = entites.Fees,
                    StartDate =entites.StartDate
                };
                courses.Add(course);
            }
            return courses;
        }
    }
}
