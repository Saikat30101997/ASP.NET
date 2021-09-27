using Autofac.Extras.Moq;
using AutoMapper;
using Moq;
using NUnit.Framework;
using ProjectEntityFrameWork.Areas.Admin.Models;
using ProjectEntityFrameWork.Training.BusinessObjects;
using ProjectEntityFrameWork.Training.Services;
using System.Diagnostics.CodeAnalysis;

namespace ProjectEntityFrameWork.Tests
{
    [ExcludeFromCodeCoverage] //microsoft er attrabute  test er ekta meserment koto gula test cover koree eta test code ta k dhore naa
    public class EditCourseModelTests
    {
        private AutoMock _mock;
        private Mock<ICourseService> _courseServiceMock;
        private Mock<IMapper> _mapperMock;
        private EditCourseModel _model;


        [OneTimeSetUp] //j object gula create korlm _mock object k initialize korar jonno 
        public void ClassSetup()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            _mock?.Dispose();  //IDispose er implement koraa ache mock e 
        }


        [SetUp]
        public void Setup()
        {
            _courseServiceMock = _mock.Mock<ICourseService>(); // mock diye duplicate instance create korbee 
            _mapperMock = _mock.Mock<IMapper>();
            _model = _mock.Create<EditCourseModel>(); // j model class test korbo setar actual class tar instance create korbo mock korboo na
        }

        [TearDown]
        public void TestCleanup()
        {
            _courseServiceMock?.Reset(); //mock gula k reset kore ditee hobe
            _mapperMock?.Reset();
        }

        [Test]
        public void LoadModelData_CourseExists_LoadProperties()
        {
            //Arrange
            const int id = 5;
            var course = new Course
            {
                Title = "Asp.net",
                Fees = 30000,
                Id = 5
            };

            _courseServiceMock.Setup(x => x.GetCourse(id)).Returns(course);
            _mapperMock.Setup(x => x.Map<EditCourseModel>(It.IsAny<Course>()))
                .Returns((Course course) =>
                {
                    return new EditCourseModel { Id = course.Id };
                });
            //act
            _model.LoadModelData(id);

            //Assert
            Assert.AreEqual(id,_model.Id);
        }
    }
}