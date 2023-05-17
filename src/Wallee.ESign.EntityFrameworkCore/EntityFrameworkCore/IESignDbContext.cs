using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Wallee.ESign.EnterpriseAuths;
using Wallee.ESign.PersonalAuths;

namespace Wallee.ESign.EntityFrameworkCore;

[ConnectionStringName(ESignDbProperties.ConnectionStringName)]
public interface IESignDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    DbSet<EnterpriseAuth> EnterpriseAuths { get; }
    DbSet<PersonalAuth> PersonalAuths { get; }
}
