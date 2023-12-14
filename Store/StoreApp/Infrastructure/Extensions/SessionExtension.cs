using System.Text.Json;

namespace StoreApp.Infrastructure.Extensions    // Extensions Classes -> static class
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session, string key, object value)     // v1
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static void SetJson<T>(this ISession session, string key, T value)     // v2
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key) 
        {
            var data = session.GetString(key);

            return data is null ? default(T)
                                : JsonSerializer.Deserialize<T>(data);
        }

    }
}