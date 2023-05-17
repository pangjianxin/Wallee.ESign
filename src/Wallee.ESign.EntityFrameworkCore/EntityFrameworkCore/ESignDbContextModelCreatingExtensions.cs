using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Wallee.ESign.EnterpriseAuths;
using Wallee.ESign.PersonalAuths;

namespace Wallee.ESign.EntityFrameworkCore;

public static class ESignDbContextModelCreatingExtensions
{
    public static void ConfigureESign(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(ESignDbProperties.DbTablePrefix + "Questions", ESignDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */

        builder.Entity<EnterpriseAuth>(it =>
        {
            it.ToTable(ESignDbProperties.DbTablePrefix + "EnterpriseAuths", ESignDbProperties.DbSchema);
            it.ConfigureByConvention();
        });

        builder.Entity<PersonalAuth>(it =>
        {
            it.ToTable(ESignDbProperties.DbTablePrefix + "PersonalAuths", ESignDbProperties.DbSchema);
            it.ConfigureByConvention();

        });
    }
}
