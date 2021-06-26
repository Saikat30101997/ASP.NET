using FirstDemo.Data;
using FirstDemo.Training.Contexts;
using FirstDemo.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Training.Repositories
{
    public class StudentRepository : Repository<Student>
    {

        public StudentRepository(TrainingContext context)
            : base(context)
        {

        }
    }
}
