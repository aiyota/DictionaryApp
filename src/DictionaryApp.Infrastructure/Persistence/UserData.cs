using DataAccessLibrary.Interfaces;
using DictionaryApp.Domain.Abstractions;
using DictionaryApp.Domain.Entities;
using DictionaryApp.Infrastructure.Common.Errors;

namespace DictionaryApp.Infrastructure.Persistence;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<User> CreateAsync(User user)
    {
        var id = await QueryAsync<dynamic, Guid>(
            StoredProcedures.User.Create,
            new { 
                user.UserName, 
                user.FirstName, 
                user.LastName, 
                user.Email, 
                user.PasswordHash 
            });


        var newUser = await GetByIdAsync(id);
        return newUser!;
    }

    public Task<bool> DeleteAsync(Guid userId)
    {
        return ExecuteAsync<dynamic>(StoredProcedures.User.Delete, new { Id = userId });
    }

    public Task<User?> GetByIdAsync(Guid userId)
    {
        return QueryAsync<dynamic, User>(StoredProcedures.User.Get, new { Id = userId });
    }

    public Task<User?> GetByUserNameAsync(string userName)
    {
        return QueryAsync<dynamic, User>(StoredProcedures.User.Get, new { UserName = userName });
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return QueryAsync<dynamic, User>(StoredProcedures.User.Get, new { Email = email });
    }

    public async Task<User> UpdateAsync(
        Guid id,
        string? userName = null,
        string? firstName = null,
        string? lastName = null,
        string? email = null,
        string? passwordHash = null)
    {
        await QueryAsync<dynamic, User>(
            StoredProcedures.User.Update,
            new
            {
                Id = id,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PasswordHash = passwordHash
            });
        var user = await GetByIdAsync(id);

        if (user is null)
            throw new RecordDoesNotExistException();

        return user;
    }

    private async Task<TOutput?> QueryAsync<TParams, TOutput>(string storedProcedure, TParams parameters)
    {
        var result = await _db.QueryAsync<TParams, TOutput>(
            storedProcedure,
            parameters);

        if (result is null)
            throw new NoResultException();

        return result.FirstOrDefault();
    }

    private Task<bool> ExecuteAsync<TParams>(string storedProcedure, TParams parameters)
    {
        return _db.ExecuteAsync(storedProcedure, parameters);
    }
}
