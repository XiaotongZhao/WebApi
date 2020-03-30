using Infrastructure.Common.RepositoryTool;
using Infrastructure.MemoryCache.Redis.ConnectionFactory;
using System.Linq;

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

        public int CreateBlog(Entity.Blog blog)
        {
            return blogRepository.Add(blog);
        }

        public int UpdateBlog(Entity.Blog blog)
        {
            return blogRepository.Update(blog);
        }

        public IQueryable<Entity.Blog> GetBlogs()
        {
            return blogRepository.GetAll();
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

        public Entity.Blog GetBlogById(long id)
        {
            return blogRepository.GetById(id);
        }
    }
}
