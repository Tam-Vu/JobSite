
namespace JobSite.Infrastructure.Skills.Persistence;
public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        // builder.Property(x => x.Name).IsRequired();
        // builder.Property(x => x.Description);
        builder.HasOne(c => c.Resume)
            .WithMany(c => c.Skills)
            .HasForeignKey(c => c.ResumeId);
    }
}