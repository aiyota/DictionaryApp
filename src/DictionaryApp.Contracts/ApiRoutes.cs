namespace DictionaryApp.Contracts;

public static class ApiRoutes
{
    public const string Root = "api";
    public const string Base = Root + "/";

    public static class Auth
    {
        public const string Name = Base + "auth";
        public const string Login = "login";
        public const string Logout = "logout";
        public const string Register = "register";
        public const string GetCurrentUser = "me";
        public const string UpdateCurrentUser = "update-me";
        public const string Refresh = "refresh";
    }
}
