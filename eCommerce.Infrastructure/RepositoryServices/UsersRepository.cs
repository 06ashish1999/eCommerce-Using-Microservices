using eCommerce.Core.Entities;
using eCommerce.Core.Enums;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.RepositoryServices;

public class UsersRepository : IUsersRepository
{
    public async Task<ApplicationUser> AddUser(ApplicationUser applicationUser)
    {
        applicationUser.UserId = Guid.NewGuid();
        return new ApplicationUser()
        {
            UserId = applicationUser.UserId,
            Email = applicationUser.Email,
            Password = applicationUser.Password,
            PersonName = "dummy person",
            Gender = Gender.Male.ToString(),
        };
    }

    public async Task<ApplicationUser> GetUserByEmailAndPassword(string? emailAddress, string? password)
    {
        return new ApplicationUser()
        {
            UserId = Guid.NewGuid(),
            Email = emailAddress,
            Password = password,
            PersonName = "dummy existing person",
            Gender = Gender.Male.ToString(),
        };
    }
}
