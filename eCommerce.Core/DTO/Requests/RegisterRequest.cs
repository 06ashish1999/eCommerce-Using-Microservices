using eCommerce.Core.Enums;

namespace eCommerce.Core.DTO.Requests;

public record RegisterRequest(string? Email, string? Password, string? PersonName, Gender Gender);
