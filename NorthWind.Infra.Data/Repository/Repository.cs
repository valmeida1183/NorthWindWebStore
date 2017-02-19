using NorthWind.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace NorthWind.Infra.Data.Repository
{
    // Classe de repositório base para todos os repositórios.
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //Protected para poder utilizar nos repositórios mais específicos.
        protected NorthWindContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(NorthWindContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            return objreturn.Entity;
                        
        }       

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetAll(int skip, int take)
        {
            // para trazer em grupos, pois podem existir muitos dados, bom para paginação.
            return DbSet.ToList().Skip(skip).Take(take);
        }

        public virtual TEntity GetById(int id, bool noTracking = false)
        {
            if (noTracking)
            {
                Db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                var entity = DbSet.Find(id);
                Db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;

                return entity;
            }

            return DbSet.Find(id);
        }

       

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TEntity Update(TEntity obj)
        {
            var entry = Db.Entry(obj);            
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }
    }
}
