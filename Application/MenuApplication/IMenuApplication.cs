using System.Threading.Tasks;
using System.Collections.Generic;
using Application.MenuApplication.MenuViewModels;

namespace Application.MenuApplication
{
    public interface IMenuApplication
    {
        Task<List<MenuViewModel>> GetMenuData();
        string TestCache();
    }
}
