using Infrastructure.Common.ViewModels;

namespace Application.MenuApplication.MenuViewModels
{
    public class ChildMenuViewModel : BaseViewModel<int>
    {
        public string ChildMenuName { get; set; }
        public string Url { get; set; }
        public string ViewId { get; set; }
    }
}
