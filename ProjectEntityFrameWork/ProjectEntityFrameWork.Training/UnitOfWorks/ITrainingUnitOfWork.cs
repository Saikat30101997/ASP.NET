
using ProjectEntityFrameWork.Data;
using ProjectEntityFrameWork.Training.Repositories;

namespace ProjectEntityFrameWork.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork
    {
        IStudentRepository Students { get; }
        ICourseRepository  Courses { get; }
    }
}