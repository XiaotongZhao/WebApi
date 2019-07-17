using Infrastructure.Common.RepositoryTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.PermissionService.Entity
{
    public class User : EntityBase<int>
    {
        public string Name { get; set; }
        public virtual IQueryable<Permission> Permissions { get; set; }
    }
}
