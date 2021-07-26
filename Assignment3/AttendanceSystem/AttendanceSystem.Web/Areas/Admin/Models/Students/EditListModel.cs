using AttendanceSystem.Management.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AttendanceSystem.Management.BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace AttendanceSystem.Web.Areas.Admin.Models.Students
{
    public class EditListModel
    {
        [Required]
        public int? Id { get; set; }
        [Required,MaxLength(300,ErrorMessage ="Name must be in 300 characters")]
        public string Name { get; set; }
        [Required, Range(11608001, 11608099,ErrorMessage ="Roll number must be between " +
            "11608001 and 11608099")]
        public int? StudentRollNumber { get; set; }

        private readonly IStudentService _studentService;
        public EditListModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }

        public EditListModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public  void LoadModelData(int id)
        {
            var student = _studentService.GetStudent(id);
            Id = student?.Id;
            Name = student?.Name;
            StudentRollNumber = student?.StudentRollNumber;
        }

        internal void Update()
        {
            var student = new Student
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                StudentRollNumber = StudentRollNumber.HasValue ? StudentRollNumber.Value : 0
            };

            _studentService.Update(student);
        }
    }
}
