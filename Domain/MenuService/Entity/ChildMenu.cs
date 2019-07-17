using Infrastructure.Common.RepositoryTool;

namespace Domain.MenuService.Entity
{
    public class ChildMenu : EntityBase<int>
    {
        public string ChildMenuName { get; set; }
        public string Url { get; set; }
        public virtual Menu Menu { get; set; }
        public int MenuId { get; set; }
        public string ViewId { get; set; }
    }
}