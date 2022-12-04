using System.ComponentModel.DataAnnotations;

namespace DictionaryApp.Contracts.Authentication;

public record LoginRequest(
    [Required]
    string UserName,

    [Required]
    [MinLength(8)]
    string Password
);