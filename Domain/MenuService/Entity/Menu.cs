using Infrastructure.Common.RepositoryTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.MenuService.Entity
{
    public class Menu : EntityBase<int>
    {
        public Menu()
        {
        }
        public string MenuName { get; set; }
        public virtual List<ChildMenu> childMenus { get; set; }

        public List<ChildMenu> AddChildMenu(ChildMenu childMenu)
        {
            childMenus.ToList().Add(childMenu);
            return childMenus.ToList();
        }
    }
}
