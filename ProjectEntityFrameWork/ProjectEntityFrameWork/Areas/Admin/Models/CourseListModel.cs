using Autofac;
using Microsoft.AspNetCore.Http;
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
        private readonly ICourseService _courseService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CourseListModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public CourseListModel(ICourseService courseService,IHttpContextAccessor httpContextAccessor)
        {
            _courseService = courseService;
            _httpContextAccessor = httpContextAccessor;
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

         public void Delete(int id)
        {
            _courseService.DeleteCourse(id);
        }
    }
}
