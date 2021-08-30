
using Microsoft.EntityFrameworkCore;
using ProjectEntityFrameWork.Data;
using ProjectEntityFrameWork.Training.Contexts;
using ProjectEntityFrameWork.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Training.UnitOfWorks
{
    public class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public IStudentRepository Students { get; private set; }
        public ICourseRepository Courses { get; private set; }

        public ICompanyRepository Companies { get; private set; }
        public IStockPriceRepository StockPrices { get; private set; }

        public TrainingUnitOfWork(ITrainingContext context,
            IStudentRepository students,
            ICourseRepository courses,ICompanyRepository companies,
            IStockPriceRepository stockPrices
            ) : base((DbContext)context)
        {
            Students = students;
            Courses = courses;
            Companies = companies;
            StockPrices = stockPrices;
        }
    }
}
