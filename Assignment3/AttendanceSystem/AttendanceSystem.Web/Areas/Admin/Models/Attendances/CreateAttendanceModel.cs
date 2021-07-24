using AttendanceSystem.Management.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AttendanceSystem.Management.BusinessObjects;

namespace AttendanceSystem.Web.Areas.Admin.Models.Attendances
{
    public class CreateAttendanceModel
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        private readonly IAttendanceService _attendanceService;

        public CreateAttendanceModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }

        public CreateAttendanceModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        public void CreateAttendance()
        {
            var attendance = new Attendance
            {
                StudentId = StudentId,
                Date = Date
            };
            _attendanceService.Create(attendance);
        }
    }
}
