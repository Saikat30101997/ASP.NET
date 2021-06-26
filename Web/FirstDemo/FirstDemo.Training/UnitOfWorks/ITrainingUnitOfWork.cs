using FirstDemo.Data;
using FirstDemo.Training.Entities;

namespace FirstDemo.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork
    {
        IRepository<Course> Courses { get; }
        IRepository<Student> Students { get; }
    }
}