
using JobSite.Domain.Enums;

namespace JobSite.Infrastructure.Jobs.Persistence;
public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Salary)
            .HasColumnType("decimal(18,2)");
        builder.Property(x => x.Status)
        .HasDefaultValue(JobStatus.Active);
        builder.Property(x => x.EmployerId).IsRequired();

        builder
            .HasOne(x => x.Employer)
            .WithMany(x => x.Jobs)
            .HasForeignKey(x => x.EmployerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}