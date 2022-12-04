using DictionaryApp.Application.Abstractions;
using BC = BCrypt.Net.BCrypt;

namespace DictionaryApp.Application.Services;

public class BcryptHashingService : IHashingService
{
    public string HashPassword(string password) =>
        BC.HashPassword(password);

    public bool VerifyPassword(string passwordHash, string password) =>
        BC.Verify(password, passwordHash);
}
