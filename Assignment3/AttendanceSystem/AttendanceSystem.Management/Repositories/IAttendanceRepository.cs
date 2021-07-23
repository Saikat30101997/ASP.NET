using AttendanceSystem.Data;
using AttendanceSystem.Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Management.Repositories
{
    public interface IAttendanceRepository : IRepository<Attendance,int>
    {

    }
}
