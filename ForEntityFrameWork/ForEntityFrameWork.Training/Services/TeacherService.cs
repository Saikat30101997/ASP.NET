using ForEntityFrameWork.Training.businessObject;
using ForEntityFrameWork.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        public TeacherService(ITrainingUnitOfWork trainingUnitOfWork)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
        }
        public IList<Teacher> GetAllTeachers()
        {
            var teacherList = _trainingUnitOfWork.Teachers.GetAll();

            var teachers = new List<Teacher>();
            foreach (var entities in teacherList)
            {
                var teacher = new Teacher()
                {
                    Id=entities.Id,
                    Name = entities.Name,
                    Designation = entities.Designation
                };
                teachers.Add(teacher);
            }
            return teachers;
        }
    }
}
