using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp2.Database;
using ConsoleApp2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2
{
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class, IEntity
    {
        private readonly DbContext database;

        public EntityFrameworkRepository()
        {
            database = new UniversityContext();
            database.Database.EnsureCreated();
            database.Database.Migrate();
        }

        public void Delete(TEntity entity)
        {
            database.Set<TEntity>().Remove(entity);
            database.SaveChanges();
        }

        public IEnumerable<TEntity> GetByAll()
        {
            return database.Set<TEntity>().AsEnumerable();
        }

        public TEntity GetById(Guid id)
        {
            return database.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            database.Set<TEntity>().Add(entity);
            database.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            database.Set<TEntity>().Update(entity);
            database.SaveChanges();
        }
    }
}
