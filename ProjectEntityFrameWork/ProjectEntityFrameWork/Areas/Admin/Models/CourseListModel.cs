using Autofac;
using ProjectEntityFrameWork.Models;
using ProjectEntityFrameWork.Training.BusinessObjects;
using ProjectEntityFrameWork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Areas.Admin.Models
{
    public class CourseListModel
    {
        private ICourseService _courseService;
       
        public CourseListModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }

        public CourseListModel(ICourseService courseService)
        {
            _courseService = courseService;
        }


        internal object GetCourses(DataTablesAjaxRequestModel tableModel) //tuple return korbe courseservice er
        {
            var data = _courseService.GetCourses(
               tableModel.PageIndex,
               tableModel.PageSize,
               tableModel.SearchText,
               tableModel.GetSortText(new string[] { "Title", "Fees", "StartDate" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Title,
                                record.Fees.ToString(),
                                record.StartDate.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
    }
}
