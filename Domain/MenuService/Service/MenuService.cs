using System.Collections.Generic;
using System.Linq;
using Domain.MenuService.Entity;
using Domain.MenuService.IRepository;

namespace Domain.MenuService.Service
{
    public class MenuService : IMenuService
    {
        private IMenuRepository iRepositoty;

        public MenuService(IMenuRepository iRepositoty)
        {
            this.iRepositoty = iRepositoty;
        }
        public List<Menu> GetMenu()
        {
            return iRepositoty.GetAll().ToList();
        }
    }
}
