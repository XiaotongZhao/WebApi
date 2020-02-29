using Domain.MenuService.Entity;
using Domain.MenuService.IRepository;
using Infrastructure.Common.RepositoryTool;

namespace Infrastructure.Repository.Repository
{
    public class MenuRepository : EFRepositoryBase<Menu, int>, IMenuRepository
    {
        public MenuRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
