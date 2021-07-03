﻿
using ProjectEntityFrameWork.Data;
using System;
using System.Collections.Generic;

namespace ProjectEntityFrameWork.Training.Entities
{
    public class Course : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Fees { get; set; }
        public DateTime StartDate { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
