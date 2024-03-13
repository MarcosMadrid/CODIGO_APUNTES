using System.Text.Json;

namespace MvcCoreSession.Extensions
{
    public static class SessionExtension
    {
        public static T? GetObject<T>(this ISession session, string key)
        {
            string? json = session.GetString(key);
            if (json == null)
            {
                return default(T);
            }
            else
            {
                T? data = JsonSerializer.Deserialize<T>(json);
                return data;
            }
        }

        public static void SetObject(this ISession session, string key, object value)
        {
            string data = JsonSerializer.Serialize(value);
            session.SetString(key, data);
        }
    }

}
