
namespace JobSite.Infrastructure.Requirements.Persistence;
public class RequirementConfiguration : IEntityTypeConfiguration<Requirement>
{
    public void Configure(EntityTypeBuilder<Requirement> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.name).IsRequired();
        builder.Property(x => x.description);
        builder.Property(x => x.jobId).IsRequired();

        builder
            .HasOne(x => x.job)
            .WithMany()
            .HasForeignKey(x => x.jobId);
    }
}