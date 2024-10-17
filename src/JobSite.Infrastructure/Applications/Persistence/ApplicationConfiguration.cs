namespace JobSite.Infrastructure.Applications.Persistence;
public class ApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        // builder.Property(x => x.status).HasDefaultValue("Pending");
        builder.Property(x => x.JobId).IsRequired();
        builder.Property(x => x.ResumeId).IsRequired();
        builder
            .HasOne(x => x.Job)
            .WithMany(x => x.Applications)
            .HasForeignKey(x => x.JobId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Resume)
            .WithMany(x => x.Applications)
            .HasForeignKey(x => x.ResumeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}