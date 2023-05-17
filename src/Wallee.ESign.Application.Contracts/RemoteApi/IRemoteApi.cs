using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Wallee.ESign.PersonalAuths;

namespace Wallee.ESign.RemoteApi
{
    public interface IRemoteApi : ITransientDependency
    {
        Task<ESignAuthResponseDto> PersonalTelecom3Factors(CreatePersonalTelecom3FactorsDto input);
    }
}
