
namespace JobSite.Infrastructure.Jobs.Persistence;
public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.title).IsRequired();
        builder.Property(x => x.description).IsRequired(false);
        builder.Property(x => x.location).IsRequired(false);
        builder.Property(x => x.salary).IsRequired(false);
        builder.Property(x => x.jobType).IsRequired();
        builder.Property(x => x.jobStatus).HasDefaultValue("Active");
        builder.Property(x => x.employerId).IsRequired();

        builder
            .HasOne(x => x.employer)
            .WithMany()
            .HasForeignKey(x => x.employerId);
        builder
            .HasMany(x => x.applications)
            .WithOne()
            .HasForeignKey(x => x.jobId);
        builder
            .HasMany(x => x.interviewSchedules)
            .WithOne()
            .HasForeignKey(x => x.jobId);
    }
}