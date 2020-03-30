using Infrastructure.Common.SearchModels.Tools;

namespace Application.BlogApplication.ViewModel
{
    public class BlogSearch : BaseSearch
    {
        public string Name { get; set; }
        public long TypeId { get; set; }
    }
}
