using AttendanceSystem.Management.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AttendanceSystem.Management.BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace AttendanceSystem.Web.Areas.Admin.Models.Attendances
{
    public class EditAttendanceModel
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public int? StudentId { get; set; }
        [Required]
        public DateTime? Date { get; set; }

        private readonly IAttendanceService _attendanceService;
        public EditAttendanceModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }
        public EditAttendanceModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        public void LoadModelData(int id)
        {
            var attendance = _attendanceService.GetAttendance(id);
            Id = attendance?.Id;
            StudentId = attendance?.StudentId;
            Date = attendance?.Date;
        }

        public void Update()
        {
            var attendance = new Attendance
            {
                Id = Id.HasValue ? Id.Value : 0,
                StudentId = StudentId.HasValue ? StudentId.Value : 0,
                Date = Date.HasValue ? Date.Value : DateTime.MinValue
            };
            _attendanceService.Update(attendance);
        }
    }
}
