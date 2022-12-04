using DictionaryApp.Domain.Entities;

namespace DictionaryApp.Domain.Abstractions;

public interface IUserData
{
    Task<User?> GetByIdAsync(Guid userId);

    Task<User?> GetByUserNameAsync(string userName);

    Task<User> CreateAsync(User user);

    Task<User> UpdateAsync(
        Guid id,
        string? userName,
        string? firstName = null,
        string? lastName = null,
        string? email = null,
        string? passwordHash = null);

    Task<bool> DeleteAsync(Guid userId);
}
