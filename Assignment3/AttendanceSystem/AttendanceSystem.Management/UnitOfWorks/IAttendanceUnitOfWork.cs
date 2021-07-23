using AttendanceSystem.Data;
using AttendanceSystem.Management.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Management.UnitOfWorks
{
    public interface IAttendanceUnitOfWork : IUnitOfWork
    {
        IStudentRepository Students { get; }
        IAttendanceRepository Attendances { get; }
    }
}
