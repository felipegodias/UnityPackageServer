using Microsoft.Extensions.DependencyInjection;
using UnityPackageServer.Services;

namespace UnityPackageServer.Services.Aws;

public static class ServiceCollectionExtensions
{
    public static void AddUpsAwsServices(this IServiceCollection collectionService)
    {
        collectionService.AddSingleton<IFilesService, S3FilesService>();
    }
}