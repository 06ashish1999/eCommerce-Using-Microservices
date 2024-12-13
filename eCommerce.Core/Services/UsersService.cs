

using AutoMapper;
using eCommerce.Core.DTO.Requests;
using eCommerce.Core.DTO.Responses;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? existingUser =  await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        //return existingUser != null ? new AuthenticationResponse(
        //                                                          existingUser.UserId, 
        //                                                          existingUser.Email, 
        //                                                          existingUser.PersonName, 
        //                                                          existingUser.Gender, 
        //                                                          "token", 
        //                                                          true 
        //                                                         )
        // : null;

        return existingUser != null? _mapper.Map<AuthenticationResponse>(existingUser) with { Success = true, Token = "token"}: null;
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        //ApplicationUser newUser = new ApplicationUser()
        //{
        //    UserId = Guid.NewGuid(),
        //    Email = registerRequest.Email,
        //    Password = registerRequest.Password,
        //    Gender = registerRequest.Gender.ToString(),
        //    PersonName = registerRequest.PersonName
        //};

         ApplicationUser newUser = _mapper.Map<ApplicationUser>(registerRequest) with { UserId = Guid.NewGuid() };

        ApplicationUser? registeredUser =  await _usersRepository.AddUser(newUser);
        //return registeredUser == null ? null :  new AuthenticationResponse(
        //                                                                   registeredUser.UserId, 
        //                                                                   registeredUser.Email, 
        //                                                                   registeredUser.PersonName, 
        //                                                                   registeredUser.Gender, 
        //                                                                   "token", 
        //                                                                   true
        //                                                                   );

        return registeredUser == null 
                                    ? null 
                                    : _mapper.Map<AuthenticationResponse>(registeredUser) with { Success = true, Token = "token" };

    }
}
