

namespace eCommerce.Core.Entities;

/// <summary>
/// represents the ApplicationUser entity which is repsonsible to stor the user details in the database for persistency.
/// </summary>
public record ApplicationUser
{
    public Guid UserId { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PersonName { get; set; }
    public string? Gender { get; set; }
}
