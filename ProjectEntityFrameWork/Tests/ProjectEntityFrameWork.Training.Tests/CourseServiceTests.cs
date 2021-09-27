using NUnit.Framework;

namespace ProjectEntityFrameWork.Training.Tests
{
    public class CourseServiceTests
    {
        [SetUp] //setup attrbute initialization and deintialization er jonno lagee
        public void Setup() //proti test er age reset kore dwr drkr amra eta setup ba teardown e kortee pari
        {
        }

        [TearDown] //setup er biporit  
        public void TearDown()
        {

        }
        [OneTimeSetUp]
        public void OneTimeSetup()
        {

        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }
        [Test]
        public void EnrollStudents_CourseDoesnotExists_ThrowException() // eta actual test method... ei name ta evabe dwr karon holo jatey bujhte pari ami kn jinis ta test korchi  
        {
            //Arrange :test er jonno j value lagbe seta arrange section e rakhboo 

            //act : j method ta k test korte chacchi seta k call diboo 

            //assert eta holo final judgement evaluation dhorte pare
            Assert.Pass();
        }
    }
}