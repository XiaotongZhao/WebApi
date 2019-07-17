using Infrastructure.Common.ViewModels;
using System.Collections.Generic;

namespace Application.MenuApplication.MenuViewModels
{
    public class MenuViewModel : BaseViewModel<int>
    {
        public string MenuName { get; set; }
        public List<ChildMenuViewModel> ChildMenuViewModel { get; set; }
    }
}
