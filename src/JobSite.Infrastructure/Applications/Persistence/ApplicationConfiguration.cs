// namespace JobSite.Infrastructure.Applications.Persistence;
// public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
// {
//     public void Configure(EntityTypeBuilder<Application> builder)
//     {
//         builder.HasKey(x => x.Id);
//         builder.Property(x => x.Id).ValueGeneratedNever();
//         builder.Property(x => x.status).HasDefaultValue("Pending");
//         builder.Property(x => x.jobId).IsRequired();
//         builder.Property(x => x.resumeId).IsRequired();
//         builder
//             .HasOne(x => x.job)
//             .WithMany()
//             .HasForeignKey(x => x.jobId);

//         builder
//             .HasOne(x => x.resume)
//             .WithMany()
//             .HasForeignKey(x => x.resumeId);
//     }
// }