using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.RepositoryTool
{
    public interface IUnitOfWork
    {
        DbContext Get();
        int Commit();
        void CommitAsync();
        void BeginTransaction();
        int CommitTransaction();
        void RollbackTransaction();
    }
}
