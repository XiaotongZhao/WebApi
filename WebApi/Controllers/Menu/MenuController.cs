﻿using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.Controllers.Base;
using Application.MenuApplication;
using Application.MenuApplication.MenuViewModels;
using Infrastructure.MemoryCache.Redis.ConnectionFactory;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers.Menu
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseController
    {
        private readonly IMenuApplication iMenuApplication;
        private readonly IRedisConnectionFactory redisConnectionFactory;
        public MenuController(IRedisConnectionFactory redisConnectionFactory, IMenuApplication menuApplication)
        {
            this.iMenuApplication = menuApplication;
            this.redisConnectionFactory = redisConnectionFactory;
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

        [HttpGet]
        [Route("TestCache")]
        public string TestCache()
        {
            redisConnectionFactory.Set<string>("testkey", "this is a test");
            var res = redisConnectionFactory.Get<string>("testkey");
            return res;
        }
    }
}