using ForeEntityFrameWork.Data;
using ForeEntityFrameWork.Training.Context;
using ForeEntityFrameWork.Training.Entities;
using ForEntityFrameWork.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.UnitOfWorks
{
    public class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public IRepository<Student> Students { get; private set; }

        public IRepository<Course> Courses { get; private set; }
        public TrainingUnitOfWork(TrainingDbContext context) : base (context)
        {
            Courses = new CourseRepository(context);
            Students = new StudentRepository(context);
        }
    }
}
