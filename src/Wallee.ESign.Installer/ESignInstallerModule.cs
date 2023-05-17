using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Wallee.ESign;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class ESignInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ESignInstallerModule>();
        });
    }
}
