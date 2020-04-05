using Infrastructure.Common.RepositoryTool;
using Infrastructure.MemoryCache.Redis.ConnectionFactory;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Blog.Service
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<Entity.Blog, long> blogRepository;
        private readonly IRepository<Entity.BlogType, long> blogTypeRepository;
        private readonly IRedisConnectionFactory redisConnectionFactory;

        public BlogService(IRepository<Entity.Blog, long> blogRepository, IRepository<Entity.BlogType, long> blogTypeRepository, IRedisConnectionFactory redisConnectionFactory)
        {
            this.blogRepository = blogRepository;
            this.blogTypeRepository = blogTypeRepository;
            this.redisConnectionFactory = redisConnectionFactory;
        }

        public async Task CreateOrUpdateBlog(Entity.Blog blog, string typeName)
        {
            if (!blogTypeRepository.GetAll().Any(a => a.TypeName == typeName) && !string.IsNullOrEmpty(typeName))
            {
                blog.BlogType = new Entity.BlogType() { TypeName = typeName };
            }
            else
            {
                var blogTypeId = blogTypeRepository.GetAll().FirstOrDefault(a => a.TypeName == typeName)?.Id;
                blog.BlogTypeId = blogTypeId;
            }
            if(blog.Id > 0)
                await blogRepository.UpdateAsync(blog);
             else
                await blogRepository.AddAsync(blog);
        }

        public async Task<int> Delete(Entity.Blog blog)
        {
            return await blogRepository.DeleteAsync(blog);
        }

        public IQueryable<Entity.Blog> GetBlogs(string name, long typeId)
        {
            var currentDbContext = blogRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                currentDbContext = currentDbContext.Where(a => a.Name.Contains(name));
            if (typeId > 0)
                currentDbContext = currentDbContext.Where(a => a.BlogTypeId == typeId);
            return currentDbContext;
        }
        public IQueryable<Entity.BlogType> GetBlogTypes()
        {
            return blogTypeRepository.GetAll();
        }

        public string TestCache()
        {
            var res = redisConnectionFactory.Set("testkey", "this is a test value");
            var value = redisConnectionFactory.Get<string>("testkey");
            return value;
        }

        public async Task<Entity.Blog> GetBlogById(long id)
        {
            return await blogRepository.GetByIdAsync(id);
        }
    }
}
