using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeEntityFrameWork.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
