using WebApi.Controllers.Base;
using System.Threading.Tasks;
using System.Collections.Generic;
using Application.BlogApplication;
using Application.BlogApplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers.Menu
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly IBlogApplication blogApplication;

        public BlogController(IBlogApplication blogApplication)
        {
            this.blogApplication = blogApplication;
        }

        [HttpPost]
        [Route("CreateBlogInfo")]
        public async Task CreateBlogInfo(BlogInfo blogInfo)
        {
            await blogApplication.CreateBlogInfo(blogInfo);
        }

        [HttpPost]
        [Route("UpdateBlogInfo")]
        public async Task<int> UpdateBlogInfo(BlogInfo blogInfo)
        {
            return await blogApplication.UpdateBlogInfo(blogInfo);
        }

        [HttpPost]
        [Route("GetBlogInfos")]
        public async Task<List<BlogInfo>> GetBlogInfos(BlogSearch blogSearch)
        {
            return await blogApplication.GetBlogInfos(blogSearch);
        }

        [HttpPost]
        [Route("GetBlogTyps")]
        public Dictionary<long, string> GetBlogTyps()
        {
            return blogApplication.GetBlogTyps();
        }

        [HttpGet]
        [Route("GetBlogById")]
        public async Task<BlogInfo> GetBlogById(long id)
        {
            return await blogApplication.GetBlogById(id);
        }

        [HttpGet]
        [Route("TestCache")]
        public string TestCache()
        {
            return blogApplication.TestCache();
        }
    }
}