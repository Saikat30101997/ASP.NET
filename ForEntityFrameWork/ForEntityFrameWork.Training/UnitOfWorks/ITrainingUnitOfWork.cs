
using ForEntityFrameWork.Training.Context;
using ForEntityFrameWork.Training.Entities;
using ForEntityFrameWork.Data;
using ForEntityFrameWork.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork
    {
          IStudentRepository Students { get; }
          ICourseRepository Courses { get; }
    }
}
