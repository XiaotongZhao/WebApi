using System.Collections.Generic;
using Infrastructure.Common.ViewModels;

namespace Application.MenuApplication.MenuViewModels
{
    public class MenuViewModel : BaseViewModel<int>
    {
        public string MenuName { get; set; }
        public List<ChildMenuViewModel> ChildMenuViewModel { get; set; }
    }
}
