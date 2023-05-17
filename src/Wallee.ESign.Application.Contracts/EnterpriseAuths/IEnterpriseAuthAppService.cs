using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Wallee.ESign.PersonalAuths;

namespace Wallee.ESign.EnterpriseAuths
{
    public interface IEnterpriseAuthAppService : IApplicationService, ITransientDependency
    {
        Task ESignEnterpriseAuthCallback(PersonalAuthCallbackDto input);
    }
}
