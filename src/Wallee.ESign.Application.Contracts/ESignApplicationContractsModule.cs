using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Wallee.ESign;

[DependsOn(
    typeof(ESignDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ESignApplicationContractsModule : AbpModule
{

}
