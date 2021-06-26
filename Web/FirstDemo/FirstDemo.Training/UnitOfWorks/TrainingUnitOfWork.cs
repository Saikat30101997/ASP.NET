using FirstDemo.Data;
using FirstDemo.Training.Contexts;
using FirstDemo.Training.Entities;
using FirstDemo.Training.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Training.UnitOfWorks
{
    public class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public IRepository<Student> Students { get; private set; }
        public IRepository<Course> Courses { get; private set; }

        public TrainingUnitOfWork(TrainingContext context) : base(context)
        {
            Students = new StudentRepository(context);
            Courses = new CourseRepository(context);
        }
    }
}
