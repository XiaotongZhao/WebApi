using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Common
{
    public interface IUnitOfWork
    {
        DbContext Get();
        int Commit();
        Task<int> CommitAsync();
        void BeginTransaction();
        int CommitTransaction();
        void RollbackTransaction();
    }
}
