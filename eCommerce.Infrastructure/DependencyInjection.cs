using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.RepositoryServices;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// extension method to add dependency injection of Infrastructure to Ioc container
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.Add(new ServiceDescriptor(typeof(IUsersRepository), typeof(UsersRepository), ServiceLifetime.Singleton));
        return service;
    }
}
