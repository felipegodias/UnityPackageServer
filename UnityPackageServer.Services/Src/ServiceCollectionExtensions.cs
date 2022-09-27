using Microsoft.Extensions.DependencyInjection;
using UnityPackageServer.Services;

namespace UnityPackageServer.Services;

public static class ServiceCollectionExtensions
{
    public static void AddUpsServices(this IServiceCollection collectionService)
    {
        collectionService.AddSingleton<IPackagesService, PackagesService>();
    }
}