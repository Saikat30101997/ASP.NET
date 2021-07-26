using AttendanceSystem.Management.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Management.Services
{
    public interface IAttendanceService
    {
        (IList<Attendance>records,int total,int totalDisplay) GetAttendances(int pageIndex, 
            int pageSize, string searchText, string sortText);
        void Create(Attendance attendance);
        Attendance GetAttendance(int id);
        void Update(Attendance attendance);
        void Delete(int id);
    }
}
