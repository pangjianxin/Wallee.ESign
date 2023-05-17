using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Wallee.ESign.EnterpriseAuths;
using Wallee.ESign.PersonalAuths;

namespace Wallee.ESign.EntityFrameworkCore;

[ConnectionStringName(ESignDbProperties.ConnectionStringName)]
public class ESignDbContext : AbpDbContext<ESignDbContext>, IESignDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ESignDbContext(DbContextOptions<ESignDbContext> options)
        : base(options)
    {

    }

    public DbSet<EnterpriseAuth> EnterpriseAuths { get; set; }

    public DbSet<PersonalAuth> PersonalAuths { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureESign();
    }
}
