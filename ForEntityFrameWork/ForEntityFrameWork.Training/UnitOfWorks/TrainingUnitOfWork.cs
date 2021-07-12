
using ForEntityFrameWork.Training.Context;
using ForEntityFrameWork.Training.Entities;
using ForEntityFrameWork.Data;
using ForEntityFrameWork.Training.Repositories;
using Microsoft.EntityFrameworkCore;
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
        public ITeacherRepository Teachers { get; private set; }
        public TrainingUnitOfWork(ITrainingDbContext context,IStudentRepository students,
            ICourseRepository courses,ITeacherRepository teachers) : base ((DbContext)context)
        {
            Students = students;
            Courses = courses;
            Teachers = teachers;
        }
    }
}
