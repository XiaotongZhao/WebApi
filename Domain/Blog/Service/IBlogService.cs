using System.Linq;
using System.Threading.Tasks;

namespace Domain.Blog.Service
{
    public interface IBlogService
    {
        Task CreateBlog(Entity.Blog blog);
        Task<int> UpdateBlog(Entity.Blog blog);
        Task<Entity.Blog> GetBlogById(long id);
        IQueryable<Entity.Blog> GetBlogs();
        IQueryable<Entity.BlogType> GetBlogTypes();
        string TestCache();
    }
}
