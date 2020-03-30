using System.Linq;

namespace Domain.Blog.Service
{
    public interface IBlogService
    {
        int CreateBlog(Entity.Blog blog);
        int UpdateBlog(Entity.Blog blog);
        Entity.Blog GetBlogById(long id);
        IQueryable<Entity.Blog> GetBlogs();
        IQueryable<Entity.BlogType> GetBlogTypes();
        string TestCache();
    }
}
