using Localization.Resources.AbpUi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Wallee.ESign.Localization;

namespace Wallee.ESign;

[DependsOn(
    typeof(ESignApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ESignHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ESignHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ESignResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });

        ConfigureESignClient(context, configuration);
    }

    private void ConfigureESignClient(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddHttpClient("esign", client =>
        {
            client.BaseAddress = new System.Uri(configuration["ESign:BaseUrl"] ?? throw new UserFriendlyException("请检查是否配置了E签宝的访问域名(ESign:BaseUrl)")) ;
        });
    }
}
