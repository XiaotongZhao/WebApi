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
        Task<List<DicKeyAndName>> GetBlogTyps();
        Task<int> Delete(BlogInfo blogInfo);
        Task CreateOrUpdateBlog(BlogInfo blogInfo);
        string TestCache();
    }
}
