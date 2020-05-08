using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Common;

namespace Infrastructure.Repository.RepositoryImplement
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        private readonly DbSet<TEntity> dbset;
        private readonly IUnitOfWork unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            dbset = this.unitOfWork.Get().Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbset.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbset.AddAsync(entity);
        }

        public void AddAll(IEnumerable<TEntity> entities)
        {
            dbset.AddRange(entities);
        }

        public async Task AddAllAsync(IEnumerable<TEntity> entities)
        {
            await dbset.AddRangeAsync(entities);
        }

        public void Delete(TEntity entity)
        {
            dbset.Remove(entity);
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            dbset.Remove(entity);
            return await unitOfWork.CommitAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbset;
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await dbset.FindAsync(id);
        }

        public TEntity GetById(TKey id)
        {
            return dbset.Find(id);
        }

        public void Update(TEntity entity)
        {
            dbset.Update(entity);
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            dbset.Update(entity);
            return await unitOfWork.CommitAsync();
        }
    }
}
