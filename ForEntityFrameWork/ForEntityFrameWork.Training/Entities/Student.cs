using ForEntityFrameWork.Data;
using System;
using System.Collections.Generic;

namespace ForEntityFrameWork.Training.Entities
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<CourseStudents> EnrollCourses { get; set; }
    }
}
