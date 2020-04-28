using Domain.Common;

namespace Domain.Blog.Entity
{
    public class BlogType : EntityBase<long>
    {
        public string TypeName { get; set; }
    }
}
