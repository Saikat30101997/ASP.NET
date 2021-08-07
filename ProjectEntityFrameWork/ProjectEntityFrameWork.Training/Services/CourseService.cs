
using AutoMapper;
using ProjectEntityFrameWork.Common.Utilities;
using ProjectEntityFrameWork.Training.BusinessObjects;
using ProjectEntityFrameWork.Training.Exceptions;
using ProjectEntityFrameWork.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Training.Services
{
    public class CourseService : ICourseService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;

        public CourseService(ITrainingUnitOfWork trainingUnitOfWork,IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;
        }

        public IList<Course> GetAllCourses()
        {
            var courseEntities = _trainingUnitOfWork.Courses.GetAll();
            var courses = new List<Course>();

            foreach(var entity in courseEntities)
            {
                var course = new Course()
                {
                    Title = entity.Title,
                    Fees = entity.Fees
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

            if (!IsValidStartDate(course.StartDate))
                throw new InvalidOperationException("StartDate should be atleast 30 days ahead");
            
                _trainingUnitOfWork.Courses.Add(
                    new Entities.Course
                    {
                        Title = course.Title,
                        Fees = course.Fees,
                        StartDate = course.StartDate
                    }
                );

                _trainingUnitOfWork.Save();      
        }
        public void EnrollStudents(Course course,Student student)
        {
            var courseEntity = _trainingUnitOfWork.Courses.GetById(course.Id);
            if (courseEntity == null)
                throw new InvalidOperationException("Course was not Found");

            if (courseEntity.EnrolledStudents == null)
                courseEntity.EnrolledStudents = new List<Entities.CourseStudents>();

            courseEntity.EnrolledStudents.Add(new Entities.CourseStudents {
            
               Student = new Entities.Student
               {
                   Name = student.Name,
                   DateOfBirth = student.DateOfBirth
               }
            });

        }

        private bool IsTitleAlreadyUsed(string title) =>
            _trainingUnitOfWork.Courses.GetCount(x => x.Title == title) > 0;
        private bool IsTitleAlreadyUsed(string title,int id) =>
            _trainingUnitOfWork.Courses.GetCount(x => x.Title == title && x.Id!=id) > 0;

        private bool IsValidStartDate(DateTime date) =>
            date.Subtract(_dateTimeUtility.Now).TotalDays > 30;

        public (IList<Course> records, int total, int totalDisplay) GetCourses(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var courseData =  _trainingUnitOfWork.Courses.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null : x => x.Title.Contains(searchText), sortText, string.Empty,
                pageIndex,pageSize);

            var resultData = (from course in courseData.data
                              select _mapper.Map<Course>(course)).ToList();


            return (resultData, courseData.total, courseData.totalDisplay);
        }
        public Course GetCourse(int Id)
        {
            var course = _trainingUnitOfWork.Courses.GetById(Id);

            return new Course
            {
                Id = course.Id,
                Title = course.Title,
                Fees = course.Fees,
                StartDate = course.StartDate
                
            };
        }

        public void Update(Course course)
        {
            if (course == null)
                throw new InvalidOperationException("Course is Missing");
            if (IsTitleAlreadyUsed(course.Title, course.Id))
                throw new DuplicateTitleException("Title is Already in Database");

            var courseEntity = _trainingUnitOfWork.Courses.GetById(course.Id);
            if (courseEntity != null)
            {
                courseEntity.Title = course.Title;
                courseEntity.Fees = course.Fees;
                courseEntity.StartDate = course.StartDate;

                _trainingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't Find Course");

            
        }

        public void DeleteCourse(int id)
        {
            _trainingUnitOfWork.Courses.Remove(id);
            _trainingUnitOfWork.Save();
        }
    }
}
