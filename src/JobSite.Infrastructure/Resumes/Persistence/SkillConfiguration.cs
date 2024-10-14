
namespace JobSite.Infrastructure.Skills.Persistence;
public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.name).IsRequired();
        builder.Property(x => x.description);
        builder.HasOne(c => c.resume)
            .WithMany()
            .HasForeignKey(c => c.resumeId);
    }
}