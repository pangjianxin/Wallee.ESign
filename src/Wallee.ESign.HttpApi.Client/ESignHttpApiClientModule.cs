using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Wallee.ESign;

[DependsOn(
    typeof(ESignApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ESignHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ESignApplicationContractsModule).Assembly,
            ESignRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ESignHttpApiClientModule>();
        });
    }
}
