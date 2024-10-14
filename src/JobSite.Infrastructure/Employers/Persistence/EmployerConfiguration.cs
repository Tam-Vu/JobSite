
namespace JobSite.Infrastructure.Employers.Persistence;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employer>
{
    public void Configure(EntityTypeBuilder<Employer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.name).IsRequired();
        builder.Property(x => x.description);
        builder.Property(x => x.location);
        builder.Property(x => x.website);
        builder.Property(x => x.sector);
        builder.Property(x => x.accountId).IsRequired();
        builder
            .HasOne(x => x.account)
            .WithMany()
            .HasForeignKey(x => x.accountId);

        builder
            .HasMany(x => x.jobs)
            .WithOne()
            .HasForeignKey(x => x.employerId);
    }
}