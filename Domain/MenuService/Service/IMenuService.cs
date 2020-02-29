using System.Collections.Generic;
using Domain.MenuService.Entity;

namespace Domain.MenuService.Service
{
    public interface IMenuService
    {
        List<Menu> GetMenu();
        string TestCache();
    }
}
