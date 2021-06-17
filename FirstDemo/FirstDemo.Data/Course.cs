using System;

namespace FirstDemo.Data
{
    public class Course //POCO CLass bole thake -> Pain OLD CLR Object 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public  int Fees { get; set; }
        public DateTime StartTime { get; set; }
    }
}
