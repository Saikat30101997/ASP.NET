
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
    public interface ICourseRepository : IRepository<Course, int, TrainingContext>
    {
    }
}
