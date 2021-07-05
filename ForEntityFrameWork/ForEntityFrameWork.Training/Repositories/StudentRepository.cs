
using ForEntityFrameWork.Training.Context;
using ForEntityFrameWork.Training.Entities;
using ForEntityFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ForEntityFrameWork.Training.Repositories
{
    public class StudentRepository : Repository<Student,int>,
        IStudentRepository
    {
        public StudentRepository(ITrainingDbContext context):base((DbContext)context)
        {

        }
    }
}
