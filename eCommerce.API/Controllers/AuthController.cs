using eCommerce.Core.DTO.Requests;
using eCommerce.Core.DTO.Responses;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")] // api/auth
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;
    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [Route("register")]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        // check for invalid register request
        if (registerRequest == null)
        {
            return BadRequest("Invalid registration data");
        }

        // call the user service to register the user
       AuthenticationResponse? authenticationResponse =   await _usersService.Register(registerRequest);

        return authenticationResponse == null || authenticationResponse.Success == false ? 
                                                                                          BadRequest(authenticationResponse): 
                                                                                          Ok(authenticationResponse);
    }

    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        // check for invalid register request
        if (loginRequest == null)
        {
            return BadRequest("Invalid registration data");
        }

        // call the user service to login the user
        AuthenticationResponse? existingUser =  await _usersService.Login(loginRequest);

        return existingUser == null || existingUser.Success == false ? Unauthorized(existingUser): Ok(existingUser);
    }
}
