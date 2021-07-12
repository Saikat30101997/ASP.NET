using ForEntityFrameWork.Data;
using ForEntityFrameWork.Training.Context;
using ForEntityFrameWork.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.Repositories
{
    public class TeacherRepository : Repository<Teacher,int> ,
        ITeacherRepository
    {
        public TeacherRepository(ITrainingDbContext context) 
            : base((DbContext)context)
        {

        }
    }
}
