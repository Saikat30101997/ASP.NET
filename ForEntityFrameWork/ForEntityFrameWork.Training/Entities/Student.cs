using ForEntityFrameWork.Data;
using System;

namespace ForeEntityFrameWork.Training.Entities
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
