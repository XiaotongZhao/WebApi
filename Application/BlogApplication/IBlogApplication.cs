using System.Collections.Generic;
using Application.BlogApplication.ViewModel;

namespace Application.BlogApplication
{
    public interface IBlogApplication
    {
        BlogInfo GetBlogById(long id);
        List<BlogInfo> GetBlogInfos(BlogSearch blogSearch);
        Dictionary<long, string> GetBlogTyps();
        int CreateBlogInfo(BlogInfo blogInfo);
        int UpdateBlogInfo(BlogInfo blogInfo);
        string TestCache();
    }
}
