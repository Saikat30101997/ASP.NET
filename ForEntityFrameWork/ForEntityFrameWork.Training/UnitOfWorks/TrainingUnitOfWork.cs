
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
    public class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public IStudentRepository Students { get; private set; }

        public ICourseRepository Courses { get; private set; }
        public TrainingUnitOfWork(TrainingDbContext context,IStudentRepository students,ICourseRepository courses) : base (context)
        {
            Courses = courses;
            Students = students;
        }
    }
}
