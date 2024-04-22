using StackExchange.Redis;

namespace MvcCoreCacheRedis.Helpers
{
    public class HelperCacheMultiplexer
    {
        private static Lazy<ConnectionMultiplexer>
            CreateConnection = new Lazy<ConnectionMultiplexer>
            (() =>
            {
                string cacheRedisKey = "cacheredismmb.redis.cache.windows.net:6380,password=0gyrucUjsRIkRmM1dhrR1UUqrtWB1rFzMAzCaA9z9ZI=,ssl=True,abortConnect=False";
                return ConnectionMultiplexer.Connect(cacheRedisKey);
            });
        public static ConnectionMultiplexer Connection
        {
            get { return CreateConnection.Value; }
        }
    }
}
