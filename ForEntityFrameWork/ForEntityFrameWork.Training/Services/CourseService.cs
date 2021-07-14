using ForEntityFrameWork.Training.Context;
using ForEntityFrameWork.Training.businessObject;
using ForEntityFrameWork.Training.UnitOfWorks;
using ForeEntityFrameWork.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForEntityFrameWork.Training.Exceptions;
using ForEntityFrameWork.Common.Utilites;

namespace ForEntityFrameWork.Training.Services
{
    public class CourseService : ICourseService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtlity _dateTimeUtility;
        public CourseService(ITrainingUnitOfWork trainingUnitOfWork,IDateTimeUtlity dateTimeUtlity)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtlity;
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
            if (course == null)
                throw new InvalidParameterException("Course was not provided");
            if (IsTitleAlreadyUsed(course.Title))
                throw new DuplicateTitleException("Course Title already exists");

            if (IsValidStartDate(course.StartDate))
                throw new InvalidOperationException("Start Date should be 30 days ahead");

            _trainingUnitOfWork.Courses.Add(
                new Entities.Course
                {
                    Title = course.Title,
                    Fees = course.Fees,
                    StartDate = course.StartDate

                });
            _trainingUnitOfWork.Save();
        }
       
        private bool IsTitleAlreadyUsed(string name) =>
            _trainingUnitOfWork.Courses.GetCount(x => x.Title == name) > 0;

        private bool IsValidStartDate(DateTime date) =>
            date.Subtract(_dateTimeUtility.Now).TotalDays > 30;
    }
}
