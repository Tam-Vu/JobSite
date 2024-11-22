using Mapster;

namespace JobSite.Application.Jobs.Commands.UpdateJob;

public static class UpdateJobMappingConfig
{
    public static void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateJobCommand, Job>()
            .Map(dest => dest.Title, src => src.title)
            .Map(dest => dest.Description, src => src.description)
            .Map(dest => dest.Requirement, src => src.requirement)
            .Map(dest => dest.Benefit, src => src.benefit)
            .Map(dest => dest.Location, src => src.location)
            .Map(dest => dest.JobType, src => src.jobType)
            .Map(dest => dest.Salary, src => src.salary);
    }
}