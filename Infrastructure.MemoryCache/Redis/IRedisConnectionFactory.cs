using StackExchange.Redis;

namespace Infrastructure.MemoryCache.Redis
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection();
    }
}
