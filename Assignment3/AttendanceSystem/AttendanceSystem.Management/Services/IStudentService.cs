using AttendanceSystem.Management.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Management.Services
{
    public interface IStudentService
    {
        (IList<Student>records,int total,int totalDisplay) GetStudents(int pageIndex, 
            int pageSize, string searchText, string sortText);
        void CreateStudent(Student student);
        Student GetStudent(int id);
        void Update(Student student);
        void Delete(int id);
    }
}
