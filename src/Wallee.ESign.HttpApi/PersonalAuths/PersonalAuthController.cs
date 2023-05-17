using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;

namespace Wallee.ESign.PersonalAuths
{
    [RemoteService(Name = ESignRemoteServiceConsts.RemoteServiceName)]
    [Route("api/app/personalAuth")]
    //[Authorize]
    public class PersonalAuthController : ESignController, IPersonalAuthAppService
    {
        private readonly IPersonalAuthAppService _personalAuthAppService;

        public PersonalAuthController(IPersonalAuthAppService personalAuthAppService)
        {
            _personalAuthAppService = personalAuthAppService;
        }

        [HttpPost]
        [Route("e-sign/personal-auth")]
        public async Task<PersonalAuthDto> ESignPersonalAuth(CreatePersonalTelecom3FactorsDto input)
        {
            return await _personalAuthAppService.ESignPersonalAuth(input);
        }

        [HttpPost]
        [Route("e-sign/personal-auth/callback")]
        public async Task ESignPersonalAuthCallback(PersonalAuthCallbackDto input)
        {
            await _personalAuthAppService.ESignPersonalAuthCallback(input);
        }
    }
}
