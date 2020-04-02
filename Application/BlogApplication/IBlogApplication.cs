using System.Collections.Generic;
using System.Threading.Tasks;
using Application.BlogApplication.ViewModel;
using Infrastructure.Common.SearchModels.Tools;

namespace Application.BlogApplication
{
    public interface IBlogApplication
    {
        Task<BlogInfo> GetBlogById(long id);
        Task<DataSource<BlogInfo>> GetBlogInfos(BlogSearch blogSearch);
        Dictionary<long, string> GetBlogTyps();
        Task CreateBlogInfo(BlogInfo blogInfo);
        Task<int> UpdateBlogInfo(BlogInfo blogInfo);
        string TestCache();
    }
}
