using AutoMapper;
using Application.BlogApplication.ViewModel;
using Domain.Blog.Entity;
using Domain.Blog.Service;
using System.Linq;
using System.Collections.Generic;
using Infrastructure.Common.SearchModels.Tools;

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

        public int CreateBlogInfo(BlogInfo blogInfo)
        {
            var blog = mapper.Map<Blog>(blogInfo);
            return blogService.CreateBlog(blog);
        }

        public int UpdateBlogInfo(BlogInfo blogInfo)
        {
            var blog = mapper.Map<Blog>(blogInfo);
            return blogService.CreateBlog(blog);
        }

        public List<BlogInfo> GetBlogInfos(BlogSearch blogSearch)
        {
            var blogs = blogService.GetBlogs().takePageDataAndCount(blogSearch.Skip, blogSearch.Size);
            var res = mapper.Map<List<BlogInfo>>(blogs.Data);
            return res;
        }

        public Dictionary<long, string> GetBlogTyps()
        {
            var dic = blogService.GetBlogTypes().ToDictionary(key => key.Id, value => value.TypeName);
            return dic;
        }

        public string TestCache()
        {
            return blogService.TestCache();
        }

        public BlogInfo GetBlogById(long id)
        {
            var blogInfo = mapper.Map<BlogInfo>(blogService.GetBlogById(id));
            return blogInfo;
        }
    }
}
