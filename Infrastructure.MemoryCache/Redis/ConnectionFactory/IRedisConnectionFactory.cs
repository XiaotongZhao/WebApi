using StackExchange.Redis;

namespace Infrastructure.MemoryCache.Redis.ConnectionFactory
{
    public interface IRedisConnectionFactory
    {
        T Get<T>(string key);
        bool Set<T>(string key, T value);
    }
}
