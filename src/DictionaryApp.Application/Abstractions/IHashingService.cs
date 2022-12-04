namespace DictionaryApp.Application.Abstractions;

public interface IHashingService
{
    string HashPassword(string password);
    bool VerifyPassword(string passwordHash, string password);
}