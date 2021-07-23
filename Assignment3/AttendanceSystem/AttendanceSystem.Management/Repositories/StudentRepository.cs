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
    public class StudentRepository : Repository<Student,int>,
        IStudentRepository
    {
        public StudentRepository(IAttendanceDbContext context) :
            base((DbContext)context)
        {

        }
    }
}
