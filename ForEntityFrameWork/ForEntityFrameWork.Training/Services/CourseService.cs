using ForeEntityFrameWork.Training.Context;
using ForEntityFrameWork.Training.businessObject;
using ForEntityFrameWork.Training.UnitOfWorks;
using ForeEntityFrameWork.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.Services
{
    public class CourseService : ICourseService
    {
        private readonly TrainingUnitOfWork _trainingUnitOfWork;
        public CourseService(TrainingUnitOfWork trainingUnitOfWork)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
        }
      
        public IList<Course> GetAllCourses()
        {
            var courseList = _trainingUnitOfWork.Courses.GetAll();
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
        public void CreateCourse(Course course)
        {
            _trainingUnitOfWork.Courses.Add(
                new ForeEntityFrameWork.Training.Entities.Course
                {
                    Title = course.Title,
                    Fees = course.Fees,
                    StartDate = course.StartDate

                });
            _trainingUnitOfWork.Save();
        }
    }
}
