using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Management.Exceptions
{
    public class DuplicateStudentException : Exception
    {
        public DuplicateStudentException(string message) :
            base(message)
        {

        }
    }
}
