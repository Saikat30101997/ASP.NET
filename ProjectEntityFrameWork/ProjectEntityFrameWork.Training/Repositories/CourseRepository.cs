
using Microsoft.EntityFrameworkCore;
using ProjectEntityFrameWork.Data;
using ProjectEntityFrameWork.Training.Contexts;
using ProjectEntityFrameWork.Training.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Training.Repositories
{
    public class CourseRepository : Repository<Course, int, TrainingContext>, 
        ICourseRepository
    {
        public CourseRepository(TrainingContext context)
            : base(context)
        {

        }
    }
}
