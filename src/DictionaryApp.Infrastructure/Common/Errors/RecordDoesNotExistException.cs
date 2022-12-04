namespace DictionaryApp.Infrastructure.Common.Errors;

internal class RecordDoesNotExistException : Exception
{
    public RecordDoesNotExistException() : base("Record does not exist.")
    {
    }
}
