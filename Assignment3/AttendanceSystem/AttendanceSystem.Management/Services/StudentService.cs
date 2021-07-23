using AttendanceSystem.Management.BusinessObjects;
using AttendanceSystem.Management.Exceptions;
using AttendanceSystem.Management.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Management.Services
{
    public class StudentService : IStudentService
    {
        private readonly IAttendanceUnitOfWork _attendanceUnitOfWork;
        public StudentService(IAttendanceUnitOfWork attendanceUnitOfWork)
        {
            _attendanceUnitOfWork = attendanceUnitOfWork;
        }

        public void CreateStudent(Student student)
        {
            if (student == null)
                throw new InvalidParameterException("Student was not provided");
            if (IsStudentAleardyInList(student.StudentRollNumber))
                throw new DuplicateStudentException("Student already in this List");

            _attendanceUnitOfWork.Students.Add(
                new Entities.Student
                {
                    Name = student.Name,
                    StudentRollNumber = student.StudentRollNumber
                });

            _attendanceUnitOfWork.Save();
        }

        public void Delete(int id)
        {
            _attendanceUnitOfWork.Students.Remove(id);
            _attendanceUnitOfWork.Save();
        }

        public Student GetStudent(int id)
        {
            var student = _attendanceUnitOfWork.Students.GetById(id);
            return new Student
            {
                Id = student.Id,
                Name = student.Name,
                StudentRollNumber = student.StudentRollNumber
            };
        }

        public (IList<Student> records, int total, int totalDisplay) GetStudents(int pageIndex,
            int pageSize, string searchText, string sortText)
        {
            var studentData = _attendanceUnitOfWork.Students.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
                x=>x.StudentRollNumber.ToString().Contains(searchText),
                sortText,string.Empty,pageIndex,pageSize);

            var resultData = (from student in studentData.data
                             select new Student
                             {
                                 Id=student.Id,
                                 Name = student.Name,
                                 StudentRollNumber = student.StudentRollNumber
                             }).ToList();

            return (resultData, studentData.total, studentData.totalDisplay);
        }

        public void Update(Student student)
        {
            if(student==null)
                throw new InvalidParameterException("Student was not provided");
            if(IsStudentAleardyInList(student.StudentRollNumber,student.Id))
                throw new DuplicateStudentException("Student already in this List");

            var studentEntity = _attendanceUnitOfWork.Students.GetById(student.Id);
            if (studentEntity != null)
            {
                studentEntity.Id = student.Id;
                studentEntity.Name = student.Name;
                studentEntity.StudentRollNumber = student.StudentRollNumber;
                _attendanceUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Student is not found");
        }

        private bool IsStudentAleardyInList(int studentRollNumber) =>
            _attendanceUnitOfWork.Students.GetCount(x => x.StudentRollNumber == studentRollNumber) > 0;
        private bool IsStudentAleardyInList(int studentRollNumber,int id) =>
         _attendanceUnitOfWork.Students.GetCount(x => x.StudentRollNumber == studentRollNumber && x.Id!=id) > 0;
    }
}
