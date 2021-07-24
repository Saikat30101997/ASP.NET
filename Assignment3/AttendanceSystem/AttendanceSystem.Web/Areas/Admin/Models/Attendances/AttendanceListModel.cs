using AttendanceSystem.Management.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AttendanceSystem.Web.Models;

namespace AttendanceSystem.Web.Areas.Admin.Models.Attendances
{
    public class AttendanceListModel
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceListModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }
        public AttendanceListModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        internal object GetAttendances(DataTablesAjaxRequestModel tableModel)
        {
            var data = _attendanceService.GetAttendances(
              tableModel.PageIndex,
              tableModel.PageSize,
              tableModel.SearchText,
              tableModel.GetSortText(new string[] { "StudentId", "Date" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.StudentId.ToString(),
                                record.Date.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
    }
}
