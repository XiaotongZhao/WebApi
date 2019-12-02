using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.MenuApplication;
using Application.MenuApplication.MenuViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.Controllers.Base;

namespace WebApi.Controllers.Menu
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseController
    {
        private readonly IMenuApplication iMenuApplication;
        public MenuController(IMenuApplication menuApplication)
        {
            this.iMenuApplication = menuApplication;
        }

        [HttpGet]
        [Route("GetMenuData")]
        public async Task<List<MenuViewModel>> GetMenuData()
        {
            var res =  this.iMenuApplication.GetMenuData();
            return await res;
        }

        [HttpGet]
        [Route("GetTest")]
        public string GetTest()
        {
            var secretKey = "mysupersecret_secretkey!123";
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            return secretKey;
        }
    }
}