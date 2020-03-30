using Infrastructure.Common.SearchModels.Tools;

namespace Application.BlogApplication.ViewModel
{
    public class BlogInfo : BaseViewModel<long>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string TypeName { get; set; }
        public long? BlogTypeId { get; set; }
    }
}
