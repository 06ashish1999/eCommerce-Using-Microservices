using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.Enums;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.RepositoryServices;

public class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;
    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser> AddUser(ApplicationUser applicationUser)
    {
        applicationUser.UserId = Guid.NewGuid();

        // query to insert data
        string? query = "INSERT INTO public.\"Users\"(\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\")" +
            " VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";
        int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, applicationUser);

        if (rowCountAffected > 0)
        {
            return applicationUser;
        }
        else
        {
            return null;
        }


        //return new ApplicationUser()
        //{
        //    UserId = applicationUser.UserId,
        //    Email = applicationUser.Email,
        //    Password = applicationUser.Password,
        //    PersonName = "dummy person",
        //    Gender = Gender.Male.ToString(),
        //};
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
