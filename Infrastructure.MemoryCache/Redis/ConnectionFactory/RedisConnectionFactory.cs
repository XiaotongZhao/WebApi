using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Infrastructure.MemoryCache.Redis.ConnectionFactory
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> connection;

        public RedisConnectionFactory(IOptions<RedisConfiguration> redis)
        {
            connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect($"{redis.Value.Host}:{redis.Value.Port},password={redis.Value.Password}"));
        }

        private IDatabase dataBase
        {
            get { return connection.Value.GetDatabase(); }
        }

        public T Get<T>(string key)
        {
            var value = dataBase.StringGet(key);
            var res = deserialize<T>(value);
            return res;
        }

        public bool Set<T>(string key, T value)
        {
            return dataBase.StringSet(key, serialize(value));
        }

        private byte[] serialize<T>(T value)
        {
            if (value == null)
            {
                return null;
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, value);
                byte[] objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        private T deserialize<T>(byte[] stream)
        {
            if (stream == null)
            {
                return default(T);
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(stream))
            {
                T result = (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }
    }
}
