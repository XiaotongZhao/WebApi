using Infrastructure.Common.RepositoryTool;

namespace Domain.Blog.Entity
{
    public class Blog : EntityBase<long>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public long? BlogTypeId { get; set; }
        public virtual BlogType BlogType { get; set; }
    }
}
