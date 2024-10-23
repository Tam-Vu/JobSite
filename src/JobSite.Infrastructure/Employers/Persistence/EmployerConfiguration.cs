
namespace JobSite.Infrastructure.Employers.Persistence;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employer>
{
    public void Configure(EntityTypeBuilder<Employer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        // builder.Property(x => x.name).IsRequired();
        // builder.Property(x => x.description);
        // builder.Property(x => x.location);
        // builder.Property(x => x.website);
        // builder.Property(x => x.sector);
        builder.Property(x => x.AccountId).IsRequired();
        builder
            .HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey(x => x.AccountId);

        // builder
        //     .HasMany(x => x.jobs)
        //     .WithOne()
        //     .HasForeignKey(x => x.employerId);
    }
}