
using eCommerce.Core.DTO.Requests;
using eCommerce.Core.DTO.Responses;

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// contract fro user services that contains use cases for users
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// method used to handle the user login request and response with authentication response model type
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);


    /// <summary>
    /// method used to handle the user registration request and response with authentication response object
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}
