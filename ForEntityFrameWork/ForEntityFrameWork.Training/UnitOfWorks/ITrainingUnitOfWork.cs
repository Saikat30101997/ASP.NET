using ForeEntityFrameWork.Data;
using ForeEntityFrameWork.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork :IUnitOfWork
    {
        public IRepository<Student>Students { get; }
        public IRepository<Course> Courses { get; }
    }
}
