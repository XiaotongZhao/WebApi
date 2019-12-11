using Infrastructure.Common.RepositoryTool;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MenuService.Entity
{
    public class User : EntityBase<int>
    {
        public string Name { get; set; }
    }
}
