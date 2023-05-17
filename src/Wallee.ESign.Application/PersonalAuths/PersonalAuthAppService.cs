using System.Threading.Tasks;
using Volo.Abp;
using Wallee.ESign.RemoteApi;

namespace Wallee.ESign.PersonalAuths
{
    public class PersonalAuthAppService : ESignAppService, IPersonalAuthAppService
    {
        private readonly IPersonalAuthRepository _eSignPersonalAuthRepository;
        private readonly IRemoteApi _remoteApi;

        public PersonalAuthAppService(
            IPersonalAuthRepository eSignPersonalAuthRepository,
            IRemoteApi remoteApi)
        {
            _eSignPersonalAuthRepository = eSignPersonalAuthRepository;
            _remoteApi = remoteApi;
        }

        public async Task<PersonalAuthDto> ESignPersonalAuth(CreatePersonalTelecom3FactorsDto input)
        {
            var res = await _remoteApi.PersonalTelecom3Factors(input);
            if (res.Code != 0)
            {
                throw new UserFriendlyException(res.Message);
            }

            var personalAuth = new PersonalAuth(
                GuidGenerator.Create(),
                CurrentUser.Id ?? throw new UserFriendlyException(""),
                input.Name, input.IdNo, input.MobileNo, res.Data.FlowId);

            await _eSignPersonalAuthRepository.InsertAsync(personalAuth);

            return ObjectMapper.Map<PersonalAuth, PersonalAuthDto>(personalAuth);
        }
        public async Task ESignPersonalAuthCallback(PersonalAuthCallbackDto input)
        {
            var eSignAutn = await _eSignPersonalAuthRepository.GetByAuthFlowId(input.FlowId);

            if (eSignAutn == null)
            {
                throw new UserFriendlyException("未能找到该条记录");
            }
            //TODO：Update this record by callback parameters
        }
    }
}
