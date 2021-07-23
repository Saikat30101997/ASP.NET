using AttendanceSystem.Data;
using AttendanceSystem.Management.Contexts;
using AttendanceSystem.Management.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Management.Repositories
{
    public class AttendanceRepository : Repository<Attendance,int>,
        IAttendanceRepository
    {
        public AttendanceRepository(IAttendanceDbContext context):
            base((DbContext)context)
        {

        }
    }
}
