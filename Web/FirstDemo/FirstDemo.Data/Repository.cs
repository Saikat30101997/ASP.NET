using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public Repository(DbContext context)
        {
            _dbContext = context;
        }

        public void Add(T item)
        {
            _dbContext.Set<T>().Add(item);
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            _dbContext.Set<T>().Remove(item);
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
