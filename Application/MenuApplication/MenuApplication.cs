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
        private readonly IMapper mapper;
        private IMenuService menuService;
        public MenuApplication(IMenuService menuService, IMapper mapper)
        {
            this.mapper = mapper;
            this.menuService = menuService;
        }
        public Task<List<MenuViewModel>> GetMenuData()
        {
            var res =  Task.Run(() => mapper.Map<List<MenuViewModel>>(menuService.GetMenu()));
            return res;
        }

        public string TestCache()
        {
            return menuService.TestCache();
        }
    }
}
