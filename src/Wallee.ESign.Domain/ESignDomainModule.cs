using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Wallee.ESign;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ESignDomainSharedModule)
)]
public class ESignDomainModule : AbpModule
{

}
