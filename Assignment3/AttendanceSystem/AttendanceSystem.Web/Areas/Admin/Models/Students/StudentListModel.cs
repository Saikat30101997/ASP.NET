using AttendanceSystem.Management.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AttendanceSystem.Management.BusinessObjects;
using AttendanceSystem.Web.Models;

namespace AttendanceSystem.Web.Areas.Admin.Models.Students
{
    public class StudentListModel
    {
        private readonly IStudentService _studentService; 

        public StudentListModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }

        public StudentListModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        internal object GetStudents(DataTablesAjaxRequestModel tableModel)
        {
            var data = _studentService.GetStudents(
               tableModel.PageIndex,
               tableModel.PageSize,
               tableModel.SearchText,
               tableModel.GetSortText(new string[] { "Name", "StudentRollNumber" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.StudentRollNumber.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        public void DeleteStudent(int id)
        {
            _studentService.Delete(id);
        }
    }
}
