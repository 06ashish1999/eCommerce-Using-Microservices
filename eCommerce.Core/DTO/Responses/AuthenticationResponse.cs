namespace eCommerce.Core.DTO.Responses;

public record AuthenticationResponse(Guid UserId, string? EmailAddress, string? PersonName, string? Gender, string? Token, bool Success);
