using ForEntityFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.Entities
{
    public class Teacher : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public List<Course> Courses { get; set; }

    }
}
