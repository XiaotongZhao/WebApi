using Domain.MenuService.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MenuService.Service
{
    public interface IMenuService
    {
        List<Menu> GetMenu();
    }
}
