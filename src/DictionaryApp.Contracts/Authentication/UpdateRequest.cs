using System.ComponentModel.DataAnnotations;

namespace DictionaryApp.Contracts.Authentication;

public record UpdateRequest(
    string? UserName,
    string? FirstName,
    string? LastName
);
