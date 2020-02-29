using Infrastructure.Common.RepositoryTool;

namespace Domain.MenuService.Entity
{
    public class User : EntityBase<int>
    {
        public string Name { get; set; }
    }
}
