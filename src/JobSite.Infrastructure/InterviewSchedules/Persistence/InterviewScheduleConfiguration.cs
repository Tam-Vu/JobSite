
namespace JobSite.Infrastructure.InterviewSchedules.Persistence;
public class InterviewScheduleConfiguration : IEntityTypeConfiguration<InterviewSchedule>
{
    public void Configure(EntityTypeBuilder<InterviewSchedule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.interviewDate).IsRequired();
        builder.Property(x => x.startTime).IsRequired();
        builder.Property(x => x.status);
        // .HasDefaultValue("Scheduled");
        builder.Property(x => x.resumeId).IsRequired();
        builder.Property(x => x.jobId).IsRequired();
        builder
            .HasOne(x => x.resume)
            .WithMany()
            .HasForeignKey(x => x.resumeId);

        builder
            .HasOne(x => x.job)
            .WithMany()
            .HasForeignKey(x => x.jobId);
    }
}