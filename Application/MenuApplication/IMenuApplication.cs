using Application.MenuApplication.MenuViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.MenuApplication
{
    public interface IMenuApplication
    {
        Task<List<MenuViewModel>> GetMenuData();
    }
}
