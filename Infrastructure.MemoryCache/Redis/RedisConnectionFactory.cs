using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Domain.Common;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Infrastructure.MemoryCache.Redis
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> connection;

        public RedisConnectionFactory(IOptions<RedisConfiguration> redis)
        {
            ConfigurationOptions config = new ConfigurationOptions();
            var ports = redis.Value.Port.Split(',');
            for (var i = 0; i < ports.Length; i++)
            {
                config.EndPoints.Add($"{redis.Value.Host}:{ports[i]}");
            }
            if (!redis.Value.IsDevelop)
            {
                config.Proxy = Proxy.Twemproxy;
                config.CommandMap = CommandMap.Create(new HashSet<string>
                {
                    "INFO", "CONFIG", "CLUSTER",
                    "PING", "ECHO", "CLIENT"
                }, available: false);
            }
            connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(config));
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
