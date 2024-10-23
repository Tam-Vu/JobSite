namespace JobSite.Infrastructure.Resumes.Persistence;

public class ExperienceDetailConfiguration : IEntityTypeConfiguration<ExperienceDetail>
{
    public void Configure(EntityTypeBuilder<ExperienceDetail> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder
            .HasOne(x => x.Resume)
            .WithMany(x => x.ExperienceDetails)
            .HasForeignKey(x => x.ResumeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}