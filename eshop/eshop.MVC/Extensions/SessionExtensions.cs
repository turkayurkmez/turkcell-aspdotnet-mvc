using Newtonsoft.Json;

namespace eshop.MVC.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            var serialized = JsonConvert.SerializeObject(value);
            session.SetString(key, serialized);
        }

        public static T? GetJson<T>(this ISession session, string key) where T : class, new()
        {



            if (session.Keys.Contains(key))
            {
                var json = session.GetString(key);
                return JsonConvert.DeserializeObject<T>(json);

            }

            return null;

            //if (!string.IsNullOrEmpty(json))
            //{

            //}



            // return null;

        }
    }
}
