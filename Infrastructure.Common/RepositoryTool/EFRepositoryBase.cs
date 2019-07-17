using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Common.RepositoryTool
{
    public abstract class EFRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        private IUnitOfWork unitOfWork { get; set; }
        private readonly DbSet<TEntity> dbset;
        private DbContext efContext;
        public EFRepositoryBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            efContext = this.unitOfWork.Get();
            dbset = efContext.Set<TEntity>();
        }

        public int Add(TEntity entity)
        {
            dbset.Add(entity);
            return unitOfWork.Commit();
        }

        public int AddAll(IEnumerable<TEntity> entities)
        {
            int changeCount = 0;
            unitOfWork.BeginTransaction();
            try
            {
                dbset.AddRange(entities);
                changeCount = unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
            }
            return changeCount;
        }

        public int Delete(TEntity entity)
        {
            int changeCount = 0;
            unitOfWork.BeginTransaction();
            try
            {
                dbset.Remove(entity);
                changeCount = unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
            }
            return changeCount;
        }

        public int Delete(Expression<Func<TEntity, bool>> where)
        {
            int changeCount = 0;
            unitOfWork.BeginTransaction();
            try
            {
                IEnumerable<TEntity> objects = dbset.Where<TEntity>(where).AsEnumerable();
                dbset.RemoveRange(objects);
                changeCount = unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
            }
            return changeCount;
        }

        public int DeleteAll(IEnumerable<TEntity> entities)
        {
            int changeCount = 0;
            unitOfWork.BeginTransaction();
            try
            {
                dbset.RemoveRange(entities);
                changeCount = unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
            }
            return changeCount;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault();
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbset;
        }

        public TEntity GetById(TKey id)
        {
            return dbset.Find(id);
        }

        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return dbset.Where(where);
        }

        public int Update(TEntity entity)
        {
            int changeCount = 0;
            unitOfWork.BeginTransaction();
            try
            {
                dbset.Attach(entity);
                efContext.Entry(entity).State = EntityState.Modified;
                changeCount = unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
            }
            return changeCount;
        }

        public int Update(IEnumerable<TEntity> entities)
        {
            int changeCount = 0;
            unitOfWork.BeginTransaction();
            try
            {
                dbset.AttachRange(entities);
                efContext.Entry(dbset).State = EntityState.Modified;
                changeCount = unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
            }
            return changeCount;
        }
    }
}
