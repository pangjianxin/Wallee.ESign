using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Wallee.ESign.PersonalAuths
{
    public interface IPersonalAuthAppService : IApplicationService, ITransientDependency
    {
        Task<PersonalAuthDto> ESignPersonalAuth(CreatePersonalTelecom3FactorsDto input);
        Task ESignPersonalAuthCallback(PersonalAuthCallbackDto input);
    }
}
