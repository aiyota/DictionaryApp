namespace DictionaryApp.Infrastructure.Persistence;

internal static class StoredProcedures
{
    internal static class User
    {
        public const string Create = "spUser_Create";
        public const string Delete = "spUser_Delete";
        public const string Get = "spUser_Get";
        public const string Update = "spUser_Update";
    }
}
