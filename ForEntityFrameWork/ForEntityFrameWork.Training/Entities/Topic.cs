﻿using ForEntityFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeEntityFrameWork.Training.Entities
{
    public class Topic : IEntity<int>
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public string Description { get; set; }
        public int  CourseId { get; set; }
        public Course Course { get; set; } // One to many Relationship Course nam er class thakbe karon ekta topic ekta class e thakbee

    }
}
