using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// extension to add depenedency injection of core service to Ioc container
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection service)
    {
        service.Add(new ServiceDescriptor(typeof(IUsersService), typeof(UsersService), ServiceLifetime.Transient));

        return service;
    }
}
