using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Wallee.ESign.PersonalAuths
{
    public interface IPersonalAuthRepository : IRepository<PersonalAuth, Guid>
    {
        Task<PersonalAuth> GetByAuthFlowId(string authFlowId);
    }
}
