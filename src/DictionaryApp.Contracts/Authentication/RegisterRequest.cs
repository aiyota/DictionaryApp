using System.ComponentModel.DataAnnotations;

namespace DictionaryApp.Contracts.Authentication;

public record RegisterRequest(
    [Required]
    string UserName,

    [Required]
    string FirstName,

    [Required]
    string LastName,

    [Required]
    [EmailAddress]
    string Email,

    [Required]
    [MinLength(8)]
    string Password
);
