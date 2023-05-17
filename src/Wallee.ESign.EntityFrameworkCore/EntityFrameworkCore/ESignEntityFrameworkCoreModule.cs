using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Wallee.ESign.PersonalAuths;

namespace Wallee.ESign.EntityFrameworkCore;

[DependsOn(
    typeof(ESignDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ESignEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ESignDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */

            options.AddRepository<PersonalAuth, PersonalAuthRepository>();
        });
    }
}
