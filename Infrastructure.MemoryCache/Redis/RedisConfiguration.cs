namespace Infrastructure.MemoryCache.Redis
{
    public class RedisConfiguration
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsDevelop { get; set; }
    }
}