using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallee.ESign.EntityFrameworkCore;

namespace Wallee.ESign.PersonalAuths
{
    public class PersonalAuthRepository : EfCoreRepository<IESignDbContext, PersonalAuth, Guid>, IPersonalAuthRepository
    {
        public PersonalAuthRepository(IDbContextProvider<IESignDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<PersonalAuth> GetByAuthFlowId(string authFlowId)
        {
            return await (await GetDbSetAsync()).FirstAsync(it => it.FlowId == authFlowId);
        }
    }
}
