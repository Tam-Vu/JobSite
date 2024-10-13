
namespace JobSite.Infrastructure.Resumes.Persistence;
public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
{
    public void Configure(EntityTypeBuilder<Resume> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.title).IsRequired();
        builder.Property(x => x.experience).IsRequired(false);
        builder.Property(x => x.education).IsRequired(false);
        builder.Property(x => x.file).IsRequired(false);
        builder.Property(x => x.employeeId).IsRequired();
        builder
            .HasOne(x => x.employee)
            .WithMany()
            .HasForeignKey(x => x.employeeId);
        builder
            .HasMany(x => x.applications)
            .WithOne()
            .HasForeignKey(x => x.resumeId);
        builder
            .HasMany(x => x.skills)
            .WithOne()
            .HasForeignKey(x => x.resumeId);
        builder
            .HasMany(x => x.InverviewSchedules)
            .WithOne()
            .HasForeignKey(x => x.resumeId);
    }
}