using Application.BlogApplication;
using Application.BlogApplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Controllers.Base;
using System.Collections.Generic;

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
        public int CreateBlogInfo(BlogInfo blogInfo)
        {
            return blogApplication.CreateBlogInfo(blogInfo);
        }

        [HttpPost]
        [Route("UpdateBlogInfo")]
        public int UpdateBlogInfo(BlogInfo blogInfo)
        {
            return blogApplication.UpdateBlogInfo(blogInfo);
        }

        [HttpPost]
        [Route("GetBlogInfos")]
        public List<BlogInfo> GetBlogInfos(BlogSearch blogSearch)
        {
            return blogApplication.GetBlogInfos(blogSearch);
        }

        [HttpPost]
        [Route("GetBlogTyps")]
        public Dictionary<long, string> GetBlogTyps()
        {
            return blogApplication.GetBlogTyps();
        }

        [HttpGet]
        [Route("GetBlogById")]
        public BlogInfo GetBlogById(long id)
        {
            return blogApplication.GetBlogById(id);
        }

        [HttpGet]
        [Route("TestCache")]
        public string TestCache()
        {
            return blogApplication.TestCache();
        }
    }
}