using ForEntityFrameWork.Training.businessObject;
using ForEntityFrameWork.Training.Exceptions;
using ForEntityFrameWork.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.Services
{
    public class StudentService : IStudentService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        public StudentService(ITrainingUnitOfWork trainingUnitOfWork)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
        }

        public IList<Student> GetAllStudents()
        {
            var studentList = _trainingUnitOfWork.Students.GetAll();
            var students= new List<Student>();
            foreach (var entities in studentList)
            {
                var student = new Student
                {
                    Id = entities.Id,
                    Name = entities.Name,
                    DateOfBirth = entities.DateOfBirth
                };
                students.Add(student);
            }
            return students;

        }

        public void CreateStudent(Student student)
        {
            if (student == null)
                throw new InvalidParameterException("Student was not provided");
            if(student.Name==null)
                throw new InvalidParameterException("Student was not provided");

            _trainingUnitOfWork.Students.Add(
                new Entities.Student
                {
                    Name=student.Name,
                    DateOfBirth = student.DateOfBirth
                });
            _trainingUnitOfWork.Save();

        }
      

    }
}
