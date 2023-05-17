using System;
using Volo.Abp.Domain.Repositories;

namespace Wallee.ESign.EnterpriseAuths
{
    public interface IEnterpriseAuthRepository : IRepository<EnterpriseAuth, Guid>
    {
    }
}
