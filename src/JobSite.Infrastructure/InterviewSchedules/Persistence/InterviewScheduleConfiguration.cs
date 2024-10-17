
namespace JobSite.Infrastructure.InterviewSchedules.Persistence;
public class InterviewScheduleConfiguration : IEntityTypeConfiguration<InterviewSchedule>
{
    public void Configure(EntityTypeBuilder<InterviewSchedule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        // builder.Property(x => x.interviewDate).IsRequired();
        // builder.Property(x => x.startTime).IsRequired();
        // builder.Property(x => x.status);
        // .HasDefaultValue("Scheduled");
        builder.Property(x => x.ResumeId).IsRequired();
        builder.Property(x => x.JobId).IsRequired();
        builder
            .HasOne(x => x.Resume)
            .WithMany(x => x.InverviewSchedules)
            .HasForeignKey(x => x.ResumeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Job)
            .WithMany(x => x.InterviewSchedules)
            .HasForeignKey(x => x.JobId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}