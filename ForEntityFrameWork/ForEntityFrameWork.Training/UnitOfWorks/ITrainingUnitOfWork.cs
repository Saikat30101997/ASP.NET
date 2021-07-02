
using ForeEntityFrameWork.Training.Context;
using ForeEntityFrameWork.Training.Entities;
using ForEntityFrameWork.Data;
using ForEntityFrameWork.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork :IUnitOfWork
    {
        public IStudentRepository Students { get; }
        public ICourseRepository Courses { get; }
    }
}
