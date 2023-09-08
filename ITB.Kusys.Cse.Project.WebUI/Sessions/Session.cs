using ITB.Kusys.Cse.Project.Entities.Concrete;
using ITB.Kusys.Cse.Project.Entities.Concrete.User;

namespace ITB.Cse.Project.WebUI.Sessions
{
    public static class Session
    {
        private static readonly Dictionary<string, object> SessionData = new();

        public static void Set<T>(string key, T value)
        {
            SessionData[key] = value;
        }

        public static User? User => Get<User>("login");


        private static T Get<T>(string key)
        {
            return SessionData.ContainsKey(key) ? (T)SessionData[key] : default(T);
        }

        public static bool Remove(string key)
        {
            if (!SessionData.ContainsKey(key)) return false;
            SessionData.Remove(key);
            return true;
        }

        public static void Clear()
        {
            SessionData.Clear();
        }
    }
}
