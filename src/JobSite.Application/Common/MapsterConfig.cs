
using JobSite.Application.InterviewSchedule.Commands.CreateInterviewSchedule;
using JobSite.Application.Jobs.Commands.UpdateJob;
using Mapster;

namespace JobSite.Application.Common;

public class MapsterConfig : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        UpdateJobMappingConfig.Register(config);

        CreateInterviewScheduleMappingConfig.Register(config);
        UpadateInterviewScheduleMappingConfig.Register(config);

    }
}