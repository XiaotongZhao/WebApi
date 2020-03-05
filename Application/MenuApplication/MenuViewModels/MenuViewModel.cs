using System.Collections.Generic;
using Infrastructure.Common.SearchModels.Tools;

namespace Application.MenuApplication.MenuViewModels
{
    public class MenuViewModel : BaseViewModel<int>
    {
        public string MenuName { get; set; }
        public List<ChildMenuViewModel> ChildMenuViewModel { get; set; }
    }
}
