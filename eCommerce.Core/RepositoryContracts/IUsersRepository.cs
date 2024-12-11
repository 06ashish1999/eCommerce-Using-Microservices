

using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

public interface IUsersRepository
{
    Task<ApplicationUser> AddUser(ApplicationUser applicationUser);
    Task<ApplicationUser> GetUserByEmailAndPassword(string? emailAddress, string? password);
}
