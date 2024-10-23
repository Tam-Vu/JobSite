
namespace JobSite.Infrastructure.Jobs.Persistence;
public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        // builder.Property(x => x.title).IsRequired();
        // builder.Property(x => x.description);
        // builder.Property(x => x.location);
        builder.Property(x => x.Salary)
            .HasColumnType("decimal(18,2)");
        // builder.Property(x => x.jobType).IsRequired();
        // builder.Property(x => x.jobStatus);
        // .HasDefaultValue("Active");
        builder.Property(x => x.EmployerId).IsRequired();

        builder
            .HasOne(x => x.Employer)
            .WithMany(x => x.Jobs)
            .HasForeignKey(x => x.EmployerId)
            .OnDelete(DeleteBehavior.Restrict);
        // builder
        //     .HasMany(x => x.applications)
        //     .WithOne()
        //     .HasForeignKey(x => x.jobId);
        // builder
        //     .HasMany(x => x.interviewSchedules)
        //     .WithOne()
        //     .HasForeignKey(x => x.jobId);
    }
}