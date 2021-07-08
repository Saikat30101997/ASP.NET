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
      

    }
}
