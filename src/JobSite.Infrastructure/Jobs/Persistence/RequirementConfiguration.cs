
namespace JobSite.Infrastructure.Requirements.Persistence;
public class RequirementConfiguration : IEntityTypeConfiguration<Requirement>
{
    public void Configure(EntityTypeBuilder<Requirement> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        // builder.Property(x => x.name).IsRequired();
        // builder.Property(x => x.description);
        builder.Property(x => x.JobId).IsRequired();

        builder
            .HasOne(x => x.Job)
            .WithMany(x => x.Requirements)
            .HasForeignKey(x => x.JobId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}