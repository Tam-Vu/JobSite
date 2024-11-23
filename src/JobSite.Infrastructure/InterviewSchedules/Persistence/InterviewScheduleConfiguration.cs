
using JobSite.Domain.Enums;

namespace JobSite.Infrastructure.InterviewSchedules.Persistence;
public class InterviewScheduleConfiguration : IEntityTypeConfiguration<InterviewSchedule>
{
    public void Configure(EntityTypeBuilder<InterviewSchedule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Status).HasDefaultValue(InterviewStatus.Scheduled);

        builder
            .HasOne(x => x.JobApplication)
            .WithMany(x => x.InterviewSchedules)
            .HasForeignKey(x => x.JobApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}