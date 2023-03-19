namespace DictionaryApp.Infrastructure.Persistence;

internal static class StoredProcedures
{
    internal static class User
    {
        private const string Schema = "[Auth]";
        public const string Create = $"{Schema}.[spUser_Create]";
        public const string Delete = $"{Schema}.[spUser_Delete]";
        public const string Get = $"{Schema}.[spUser_Get]";
        public const string Update = $"{Schema}.[spUser_Update]";
    }
}
