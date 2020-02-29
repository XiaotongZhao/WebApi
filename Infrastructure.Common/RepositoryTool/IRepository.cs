using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Infrastructure.Common.RepositoryTool
{
    public interface IRepository<TEntity, in TKey> where TEntity : EntityBase<TKey>
    {
        int Add(TEntity entity);
        int AddAll(IEnumerable<TEntity> entities);
        int Update(TEntity entity);
        int Update(IEnumerable<TEntity> entities);
        int Delete(TEntity entity);
        int Delete(Expression<Func<TEntity, bool>> where);
        int DeleteAll(IEnumerable<TEntity> entities);
        TEntity GetById(TKey id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
    }
}
