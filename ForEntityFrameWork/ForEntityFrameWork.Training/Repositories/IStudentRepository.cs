using ForeEntityFrameWork.Training.Context;
using ForeEntityFrameWork.Training.Entities;
using ForEntityFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.Repositories
{
    public interface IStudentRepository : IRepository<Student,int,TrainingDbContext>
    {

    }
}
