using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.MenuApplication;
using Application.MenuApplication.MenuViewModels;
using WebApi.Controllers.Base;

namespace WebApi.Controllers.Menu
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseController
    {
        private readonly IMenuApplication menuApplication;
        public MenuController(IMenuApplication menuApplication)
        {
            this.menuApplication = menuApplication;
        }

        [HttpGet]
        [Route("GetMenuData")]
        public async Task<List<MenuViewModel>> GetMenuData()
        {
            var res =  this.menuApplication.GetMenuData();
            return await res;
        }

        [HttpGet]
        [Route("TestCache")]
        public string TestCache()
        {
            return menuApplication.TestCache();
        }
    }
}