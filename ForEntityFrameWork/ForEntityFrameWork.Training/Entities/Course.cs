using ForEntityFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEntityFrameWork.Training.Entities
{
    public class Course : IEntity<int> 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Fees { get; set; }
        public DateTime StartDate { get; set; }
      
        public List<Topic> Topics { get; set; } //ekta Course e onk gulaa topic thakbe 
        public List<CourseStudents> EnrollStudents { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

    }
}
