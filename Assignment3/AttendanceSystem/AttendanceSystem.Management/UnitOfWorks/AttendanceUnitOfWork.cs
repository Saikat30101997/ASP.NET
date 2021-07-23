using AttendanceSystem.Data;
using AttendanceSystem.Management.Contexts;
using AttendanceSystem.Management.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Management.UnitOfWorks
{
    public class AttendanceUnitOfWork : UnitOfWork,
        IAttendanceUnitOfWork
    {
        public IStudentRepository Students { get; private set; }
        public IAttendanceRepository Attendances { get; private set; }

        public AttendanceUnitOfWork(IAttendanceDbContext context,
            IStudentRepository students,IAttendanceRepository attendances) : 
            base((DbContext)context)
        {
            Students = students;
            Attendances = attendances;
        }
    }
}
