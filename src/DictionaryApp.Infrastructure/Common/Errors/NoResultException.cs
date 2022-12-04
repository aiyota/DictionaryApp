using System.Data.Common;

namespace DictionaryApp.Infrastructure.Common.Errors;

internal class NoResultException : DbException
{
    public NoResultException() : base("Data access operation returned null.")
    {
    }
}
