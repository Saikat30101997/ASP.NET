﻿using ForeEntityFrameWork.Data;
using ForeEntityFrameWork.Training.Context;
using ForeEntityFrameWork.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(TrainingDbContext context):base(context)
        {

        }
    }
}
