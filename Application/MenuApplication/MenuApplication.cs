using Application.MenuApplication.MenuViewModels;
using AutoMapper;
using Domain.MenuService.Entity;
using Domain.MenuService.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.MenuApplication
{
    internal class MenuApplication : IMenuApplication
    {
        private IMenuService menuService;
        public MenuApplication(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        public Task<List<MenuViewModel>> GetMenuData()
        {
            var res =  Task.Run(() => Mapper.Map<List<Menu>, List<MenuViewModel>>(menuService.GetMenu()));
            return res;
        }

        public string TestCache()
        {
            return menuService.TestCache();
        }
    }
}
