using System;
using System.Threading.Tasks;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repository.RepositoryImplement
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private EFContext dbContext;
        private IDbContextTransaction transaction;
        private bool disposed;
        public UnitOfWork(EFContext efContext)
        {
            dbContext = efContext;
        }
        public void BeginTransaction()
        {
            if (dbContext != null)
                transaction = dbContext.Database.BeginTransaction();
            else
                return;
        }

        public int Commit()
        {
            int changeCount = dbContext.SaveChanges();
            return changeCount;
        }

        public async Task<int> CommitAsync()
        {
            int changeCount = await dbContext.SaveChangesAsync();
            return changeCount;
        }

        public int CommitTransaction()
        {
            int changeCount = 0;
            if (dbContext != null)
            {
                changeCount = dbContext.SaveChanges();
                transaction.Commit();
            }
            return changeCount;
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                if (disposed)
                    return;
                disposed = true;
                dbContext.SaveChanges();
                dbContext.Dispose();
            }
        }

        public DbContext Get()
        {
            return dbContext;
        }

        public void RollbackTransaction()
        {
            if (dbContext != null)
            {
                transaction.Rollback();
            }
            else
                return;
        }
    }
}
