using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Common
{
    public interface IRepository<TEntity, in TKey> where TEntity : EntityBase<TKey>
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddAll(IEnumerable<TEntity> entities);
        Task AddAllAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        TEntity GetById(TKey id);
        Task<TEntity> GetByIdAsync(TKey id);
        IQueryable<TEntity> GetAll();
    }
}
