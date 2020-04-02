using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.RepositoryTool
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
