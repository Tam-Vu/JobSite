
namespace JobSite.Infrastructure.Employees.Persistence;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.fullname).IsRequired();
        builder.Property(x => x.image).IsRequired(false);
        builder.Property(x => x.address).IsRequired(false);
        builder.Property(x => x.phone).IsRequired(false);
        builder.Property(x => x.email).IsRequired(false);
        builder.Property(x => x.accountId).IsRequired();
        builder
            .HasMany(x => x.resumes)
            .WithOne()
            .HasForeignKey(x => x.employeeId);

        builder
            .HasOne(x => x.account)
            .WithMany()
            .HasForeignKey(x => x.accountId);
    }
}