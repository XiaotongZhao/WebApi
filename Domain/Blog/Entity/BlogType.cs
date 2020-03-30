using Infrastructure.Common.RepositoryTool;

namespace Domain.Blog.Entity
{
    public class BlogType : EntityBase<long>
    {
        public string TypeName { get; set; }
    }
}
