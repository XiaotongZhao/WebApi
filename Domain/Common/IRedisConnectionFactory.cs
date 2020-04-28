namespace Domain.Common
{
    public interface IRedisConnectionFactory
    {
        T Get<T>(string key);
        bool Set<T>(string key, T value);
    }
}
