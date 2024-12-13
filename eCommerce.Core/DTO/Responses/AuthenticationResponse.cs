namespace eCommerce.Core.DTO.Responses;

public record AuthenticationResponse(Guid UserId, string? EmailAddress, string? PersonName, string? Gender, string? Token, bool Success)
{
    public AuthenticationResponse():this(default, default, default, default, default, default)
    {
        // We kept parameter less constructor because automapper is expectiong parmaeter less cosntructor while mapping
        // finally this will call the existing parameterized cosntructoru.
    }
};
