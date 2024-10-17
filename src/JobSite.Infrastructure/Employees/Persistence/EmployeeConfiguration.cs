
namespace JobSite.Infrastructure.Employees.Persistence;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        // builder.Property(x => x.fullname).IsRequired();
        // builder.Property(x => x.image);
        // builder.Property(x => x.address);
        // builder.Property(x => x.phone);
        // builder.Property(x => x.email);
        builder.Property(x => x.AccountId).IsRequired();
        // builder
        //     .HasMany(x => x.resumes)
        //     .WithOne()
        //     .HasForeignKey(x => x.employeeId);

        builder
            .HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}