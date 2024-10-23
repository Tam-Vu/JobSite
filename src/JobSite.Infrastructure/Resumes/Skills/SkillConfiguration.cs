
namespace JobSite.Infrastructure.Skills.Persistence;
public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();
        // builder.Property(x => x.Name).IsRequired();
        // builder.Property(x => x.Description);
    }
}