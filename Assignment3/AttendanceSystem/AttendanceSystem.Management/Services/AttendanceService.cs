using AttendanceSystem.Common.Utilities;
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
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceUnitOfWork _attendanceUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        public AttendanceService(IAttendanceUnitOfWork attendanceUnitOfWork,
            IDateTimeUtility dateTimeUtility)
        {
            _attendanceUnitOfWork = attendanceUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
        }

        public void Create(Attendance attendance)
        {
            if (attendance == null)
                throw new InvalidParameterException("Attendance was not submitted");
            if (IsStudentAlreadyInList(attendance.StudentId))
                throw new DuplicateStudentException("Student Already in Attendance List");

            if (IsDateToday(attendance.Date))
                throw new InvalidOperationException("Date is not Today");

            _attendanceUnitOfWork.Attendances.Add(
                new Entities.Attendance
                {
                    StudentId = attendance.StudentId,
                    Date = attendance.Date

                });
            _attendanceUnitOfWork.Save();
            
        }

        public (IList<Attendance> records, int total, int totalDisplay) GetAttendances(int pageIndex,
            int pageSize, string searchText, string sortText)
        {
            var attendanceData = _attendanceUnitOfWork.Attendances
                .GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null : x => x.StudentId
                .ToString().Contains(searchText),sortText,string.Empty,pageIndex,pageSize);

            var resultData = (from attendance in attendanceData.data
                              select new Attendance
                              {
                                  Id = attendance.Id,
                                  StudentId = attendance.StudentId,
                                  Date = attendance.Date
                              }).ToList();

            return (resultData, attendanceData.total, attendanceData.totalDisplay);

        }
        private bool IsStudentAlreadyInList(int studentId) =>
            _attendanceUnitOfWork.Attendances.GetCount(x => x.StudentId == studentId) > 0;

        private bool IsStudentAlreadyInList(int studentId,int id) =>
           _attendanceUnitOfWork.Attendances.GetCount(x => x.StudentId == studentId && x.Id!=id) > 0;
        private bool IsDateToday(DateTime date) =>
           (int) (date.Subtract(_dateTimeUtility.Now).TotalDays)!=0;

        public Attendance GetAttendance(int id)
        {
            var attendance = _attendanceUnitOfWork.Attendances.GetById(id);
            return new Attendance
            {
                Id = attendance.Id,
                StudentId = attendance.StudentId,
                Date = attendance.Date
            };
        }

        public void Update(Attendance attendance)
        {
            if (attendance == null)
                throw new InvalidParameterException("attendance is not submitted");
            if (IsStudentAlreadyInList(attendance.StudentId, attendance.Id))
                throw new DuplicateStudentException("Student Already in List");
            if (IsDateToday(attendance.Date))
                throw new InvalidOperationException("Date is not Today");

            var attendanceEntity = _attendanceUnitOfWork.Attendances.GetById(attendance.Id);

            if (attendanceEntity != null)
            {
                attendanceEntity.Id = attendance.Id;
                attendanceEntity.StudentId = attendance.StudentId;
                attendanceEntity.Date = attendance.Date;
                _attendanceUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Attendance is not updated");
        }

        public void Delete(int id)
        {
            _attendanceUnitOfWork.Attendances.Remove(id);
            _attendanceUnitOfWork.Save();
        }
    }
}
