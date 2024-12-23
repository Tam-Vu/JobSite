
namespace JobSite.Infrastructure.Resumes.Persistence;
public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
{
    public void Configure(EntityTypeBuilder<Resume> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.EmployeeId).IsRequired();
        builder
            .HasOne(x => x.Employee)
            .WithMany(x => x.Resumes)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.Skills)
            .WithMany();

        builder.OwnsMany(u => u.ExperienceDetails, a =>
        {
            a.HasKey(x => x.Id);
            a.Property(x => x.Id).ValueGeneratedOnAdd();
        });
    }
}