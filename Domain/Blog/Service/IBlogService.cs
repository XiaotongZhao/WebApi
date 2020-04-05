using System.Linq;
using System.Threading.Tasks;

namespace Domain.Blog.Service
{
    public interface IBlogService
    {
        Task<int> Delete(Entity.Blog blog);
        Task CreateOrUpdateBlog(Entity.Blog blog, string typeName);
        Task<Entity.Blog> GetBlogById(long id);
        IQueryable<Entity.Blog> GetBlogs(string name, long typeId);
        IQueryable<Entity.BlogType> GetBlogTypes();
        string TestCache();
    }
}
