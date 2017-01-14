using NorthWind.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace NorthWind.Infra.Data.Repository
{
    // basic class that represent all crud operations for all entities.
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected NorthWindContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(NorthWindContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Add(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            return objreturn.Entity;
                        
        }
               
        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }
    }
}
