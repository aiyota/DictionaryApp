namespace DictionaryApp.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public bool EmailedConfirmed { get; set; }
}