

namespace JobSite.Infrastructure.Accounts.Persistence;
public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        // builder.Property(x => x.username).IsRequired();
        // builder.Property(x => x.password).IsRequired();
        // builder.Property(x => x.image);
        // builder.Property(x => x.address);
        // builder.Property(x => x.isDisabled).HasDefaultValue(false);
    }
}