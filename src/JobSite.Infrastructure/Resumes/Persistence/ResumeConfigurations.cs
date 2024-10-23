
namespace JobSite.Infrastructure.Resumes.Persistence;
public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
{
    public void Configure(EntityTypeBuilder<Resume> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        // builder.Property(x => x.title).IsRequired();
        // builder.Property(x => x.experience);
        // builder.Property(x => x.education);
        // builder.Property(x => x.file);
        builder.Property(x => x.EmployeeId).IsRequired();
        builder
            .HasOne(x => x.Employee)
            .WithMany(x => x.Resumes)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(x => x.Skills)
            .WithMany();
        // .UsingEntity<Dictionary<string, object>>(
        //     "ResumeSkill",
        //     x => x.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
        //     x => x.HasOne<Resume>().WithMany().HasForeignKey("ResumeId")
        // );

        // builder
        //     .HasMany(x => x.applications)
        //     .WithOne()
        //     .HasForeignKey(x => x.resumeId);
        // builder
        //     .HasMany(x => x.skills)
        //     .WithOne()
        //     .HasForeignKey(x => x.resumeId);
        // builder
        //     .HasMany(x => x.InverviewSchedules)
        //     .WithOne()
        //     .HasForeignKey(x => x.resumeId);
    }
}