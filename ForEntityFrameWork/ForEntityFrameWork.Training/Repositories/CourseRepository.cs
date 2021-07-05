
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
    public class CourseRepository : Repository<Course,int> ,
        ICourseRepository
    {
        public CourseRepository(ITrainingDbContext context) : 
             base((DbContext)context)
        {

        }
    }
}
