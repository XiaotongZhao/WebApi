using AutoMapper;
using Application.BlogApplication.ViewModel;
using Domain.Blog.Entity;
using Domain.Blog.Service;
using System.Linq;
using System.Collections.Generic;
using Infrastructure.Common.SearchModels.Tools;
using System.Threading.Tasks;

namespace Application.BlogApplication
{
    public class BlogApplication : IBlogApplication
    {
        private readonly IMapper mapper;
        private readonly IBlogService blogService;
        public BlogApplication(IBlogService blogService, IMapper mapper)
        {
            this.mapper = mapper;
            this.blogService = blogService;
        }

        public async Task CreateBlogInfo(BlogInfo blogInfo)
        {
            var blog = mapper.Map<Blog>(blogInfo);
            await blogService.CreateBlog(blog);
        }

        public async Task<int> UpdateBlogInfo(BlogInfo blogInfo)
        {
            var blog = mapper.Map<Blog>(blogInfo);
            return await blogService.UpdateBlog(blog);
        }

        public async Task<DataSource<BlogInfo>> GetBlogInfos(BlogSearch blogSearch)
        {
            var blogs = await blogService.GetBlogs().OrderByDescending(a => a.Id).takePageDataAndCountAsync(blogSearch.Skip, blogSearch.Size);
            var res = new DataSource<BlogInfo>();
            res.Data = mapper.Map<List<BlogInfo>>(blogs.Data);
            res.Count = blogs.Count;
            return res;
        }

        public Dictionary<long, string> GetBlogTyps()
        {
            var dic = blogService.GetBlogTypes().ToDictionary(key => key.Id, value => value.TypeName);
            return dic;
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
    }
}
