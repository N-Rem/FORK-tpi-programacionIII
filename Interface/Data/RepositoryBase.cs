using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    //Clase genérica, repositorio base, T es como un comodin que nos permite usarlo en todas las entidades. 
    //Esta clase no existe hasta el momento en que se la llama a travez de otro repositorio. 
    public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        // Contexto de base de datos de Entity Framework
        private readonly DbContext _dbContext;
        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //con set<T> se accede a la lista de la base de datos definida en ApplicationContext
        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        // TId es otro tipo de "comodin que guarda el tipo de valor que es id
        public T? GetById<TId>(TId id)
        {
            return _dbContext.Set<T>().Find(new object[] { id });
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }
    }
}