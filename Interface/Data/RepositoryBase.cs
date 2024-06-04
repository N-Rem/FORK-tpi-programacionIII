using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public abstract class RepositoryBase<T> where T : class
    {
        private readonly DbContext _dbContext;
        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual T GetById<TId>(TId id) 
        { 
            return _dbContext.Set<T>().Find(new object[] { id });
        }

        public virtual T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
           _dbContext.Set<T>().Update(entity);
           _dbContext.SaveChanges();
        }
    }
}
