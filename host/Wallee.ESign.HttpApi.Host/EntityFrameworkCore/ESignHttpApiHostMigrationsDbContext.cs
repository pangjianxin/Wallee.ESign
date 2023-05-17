using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Wallee.ESign.EntityFrameworkCore;

public class ESignHttpApiHostMigrationsDbContext : AbpDbContext<ESignHttpApiHostMigrationsDbContext>
{
    public ESignHttpApiHostMigrationsDbContext(DbContextOptions<ESignHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureESign();
    }
}
