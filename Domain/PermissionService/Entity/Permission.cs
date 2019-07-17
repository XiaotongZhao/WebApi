using Infrastructure.Common.RepositoryTool;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.PermissionService.Entity
{
    public class Permission : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
