using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Application.BlogApplication.ViewModel;
using Domain.Blog.Entity;
using Domain.Blog.Service;
using Infrastructure.Common.SearchModels.Tools;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EventBus.EventBus.Abstractions;
using Application.BlogApplication.Event;

namespace Application.BlogApplication
{
    public class BlogApplication : IBlogApplication
    {
        private readonly IMapper mapper;
        private readonly IEventBus eventBus;
        private readonly IBlogService blogService;

        public BlogApplication(IEventBus eventBus, IBlogService blogService, IMapper mapper)
        {
            this.eventBus = eventBus;
            this.mapper = mapper;
            this.blogService = blogService;
        }

        public async Task<DataSource<BlogInfo>> GetBlogInfos(BlogSearch blogSearch)
        {
            var blogs = await blogService.GetBlogs(blogSearch.Name, string.IsNullOrEmpty(blogSearch.TypeId) ? 0 : long.Parse(blogSearch.TypeId))
                .OrderByDescending(a => a.Id)
                .takePageDataAndCountAsync(blogSearch.Skip, blogSearch.Size);
            var res = new DataSource<BlogInfo>
            {
                Data = mapper.Map<List<BlogInfo>>(blogs.Data),
                Count = blogs.Count
            };
            return res;
        }

        public async Task<List<DicKeyAndName>> GetBlogTyps()
        {
            var dic = blogService.GetBlogTypes()
                .Select(a => new DicKeyAndName
                {
                    Key = a.Id,
                    Name = a.TypeName
                }).ToListAsync();
            return await dic;
        }

        public async Task<BlogInfo> GetBlogById(long id)
        {
            var blogInfo = mapper.Map<BlogInfo>(await blogService.GetBlogById(id));
            return blogInfo;
        }

        public string TestCache()
        {
            return blogService.TestCache();
        }

        public async Task<int> Delete(BlogInfo blogInfo)
        {
            var blog = mapper.Map<Blog>(blogInfo);
            return await blogService.Delete(blog);
        }

        public async Task CreateOrUpdateBlog(BlogInfo blogInfo)
        {
            var blog = mapper.Map<Blog>(blogInfo);
            await blogService.CreateOrUpdateBlog(blog, blogInfo.TypeName);
        }

        public void TestPublish()
        {
            var blogIntegrationEvent = new BlogIntegrationEvent();
            blogIntegrationEvent.Name = "Test";
            eventBus.Publish(blogIntegrationEvent);
        }
    }
}
