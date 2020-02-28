using System.Linq;
using System.Collections.Generic;
using Domain.MenuService.Entity;
using Domain.MenuService.IRepository;
using Infrastructure.MemoryCache.Redis.ConnectionFactory;

namespace Domain.MenuService.Service
{
    public class MenuService : IMenuService
    {
        private IMenuRepository menuRepositoty;
        private readonly IRedisConnectionFactory redisConnectionFactory;

        public MenuService(IRedisConnectionFactory redisConnectionFactory, IMenuRepository menuRepositoty)
        {
            this.menuRepositoty = menuRepositoty;
            this.redisConnectionFactory = redisConnectionFactory;
        }
        public List<Menu> GetMenu()
        {
            return menuRepositoty.GetAll().ToList();
        }

        public string TestCache()
        {
            var res = redisConnectionFactory.Set("testkey", "this is a test value");
            var value = redisConnectionFactory.Get<string>("testkey");
            return value;
        }
    }
}
