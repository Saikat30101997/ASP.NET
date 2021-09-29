using Autofac.Extras.Moq;
using AutoMapper;
using Moq;
using NUnit.Framework;
using EO= ProjectEntityFrameWork.Training.Entities;
using ProjectEntityFrameWork.Training.BusinessObjects;
using ProjectEntityFrameWork.Training.Repositories;
using ProjectEntityFrameWork.Training.Services;
using ProjectEntityFrameWork.Training.UnitOfWorks;
using Shouldly;
using System;
using ProjectEntityFrameWork.Training.Exceptions;

namespace ProjectEntityFrameWork.Training.Tests
{
    public class CourseServiceTests
    {
        private AutoMock _mock;
        private Mock<ITrainingUnitOfWork> _trainingUnitOfWork;
        private Mock<ICourseRepository> _courseRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private ICourseService _courseService;

        [OneTimeSetUp]
        public void ClassSetup()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            _mock?.Dispose();
        }

        [SetUp]
        public void TestSetup()
        {
            _trainingUnitOfWork = _mock.Mock<ITrainingUnitOfWork>();
            _courseRepositoryMock = _mock.Mock<ICourseRepository>();
            _mapperMock = _mock.Mock<IMapper>();
            _courseService = _mock.Create<CourseService>();
        }

        [TearDown]
        public void TestCleanup()
        {
            _trainingUnitOfWork.Reset();
            _courseRepositoryMock.Reset();
            _mapperMock.Reset();
        }
        [Test]
        public void EnrollStudents_CourseDoesnotExists_ThrowException() // eta actual test method... ei name ta evabe dwr karon holo jatey bujhte pari ami kn jinis ta test korchi  
        {
            //Arrange :test er jonno j value lagbe seta arrange section e rakhboo 
            var course = new Course { Id = 5, Fees = 30000, Title = "Asp.net" };
            var student = new Student { Id = 9, Name = "Tareq" };

            EO.Course courseEntity = null;

            _courseRepositoryMock.Setup(x => x.GetById(course.Id)).Returns(courseEntity);

            _trainingUnitOfWork.Setup(x => x.Courses).Returns(_courseRepositoryMock.Object);

            //act : j method ta k test korte chacchi seta k call diboo 

            //assert eta holo final judgement evaluation dhorte pare
            Should.Throw<InvalidOperationException>(
                () => _courseService.EnrollStudents(course, student));
        }
        [Test]
        public void EnrollStudent_CourseExists_EnrollsStudent() // eta actual test method... ei name ta evabe dwr karon holo jatey bujhte pari ami kn jinis ta test korchi  
        {
            // Arrange
            var course = new Course { Id = 5, Fees = 30000, Title = "Asp.net" };
            var student = new Student { Id = 9, Name = "Tareq", DateOfBirth = DateTime.Now };

            var courseEntity = new EO.Course { Id = course.Id, Title = course.Title, Fees = course.Fees };

            _trainingUnitOfWork.Setup(x => x.Courses)
                .Returns(_courseRepositoryMock.Object);

            _courseRepositoryMock.Setup(x => x.GetById(course.Id))
                .Returns(courseEntity);

       

            // Act
            _courseService.EnrollStudents(course, student);


            //assert eta holo final judgement evaluation dhorte pare
            this.ShouldSatisfyAllConditions(
                () => _courseRepositoryMock.VerifyAll(),
                ()=>_trainingUnitOfWork.VerifyAll(),
                ()=> courseEntity.EnrolledStudents[0].Student.Name.ShouldBe(student.Name));
                    
        }
       [Test]
        public void CreateCourse_DoesnotExists_throwException()
        {
            Course course = null;
            EO.Course course1 = new EO.Course();
            _mapperMock.Setup(x => x.Map<EO.Course>(course)).Returns(course1);

            _courseRepositoryMock.Setup(x => x.Add(course1)).Verifiable();
            _trainingUnitOfWork.Setup(x => x.Courses).Returns(_courseRepositoryMock.Object);
            _trainingUnitOfWork.Setup(x => x.Save()).Verifiable();
            

            Should.Throw<InvalidParameterException>(
                () => _courseService.CreateCourse(course));

        }

    }
}