using System.Threading.Tasks;
using Wallee.ESign.PersonalAuths;

namespace Wallee.ESign.EnterpriseAuths
{
    public class EnterpriseAuthAppService : ESignAppService, IEnterpriseAuthAppService
    {
        public EnterpriseAuthAppService()
        {

        }
        public Task ESignEnterpriseAuthCallback(PersonalAuthCallbackDto input)
        {
            return Task.CompletedTask;
        }
    }
}
