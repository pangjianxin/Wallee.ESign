using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Wallee.ESign.EntityFrameworkCore;

public class ESignHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ESignHttpApiHostMigrationsDbContext>
{
    public ESignHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ESignHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("ESign"));

        return new ESignHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
