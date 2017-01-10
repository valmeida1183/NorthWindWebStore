using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NorthWind.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        void Remove(int id);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
