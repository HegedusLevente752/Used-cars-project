namespace SoftwareEngineering
{
    public static class SessionManager
    {
        public static bool IsLoggedIn { get; set; } = false;
        public static string CurrentUser { get; set; } = string.Empty;

        public static void Logout()
        {
            IsLoggedIn = false;
            CurrentUser = string.Empty;
        }
    }
}
