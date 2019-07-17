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
        private IMenuService MenuService;
        public MenuApplication(IMenuService MenuService)
        {
            this.MenuService = MenuService;
        }
        public Task<List<MenuViewModel>> GetMenuData()
        {
            var res =  Task.Run(() => Mapper.Map<List<Menu>, List<MenuViewModel>>(MenuService.GetMenu()));
            return res;
        }
    }
}
