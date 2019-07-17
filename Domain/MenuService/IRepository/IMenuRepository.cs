using Domain.MenuService.Entity;
using Infrastructure.Common.RepositoryTool;

namespace Domain.MenuService.IRepository
{
    public interface IMenuRepository : IRepository<Menu, int>
    {
    }
}
