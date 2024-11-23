using Mapster;

namespace JobSite.Application.InterviewSchedule.Commands.CreateInterviewSchedule;

using JobSite.Domain.Entities;
public class CreateInterviewScheduleMappingConfig
{
    public static void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateInterviewScheduleCommand, InterviewSchedule>()
            .Map(dest => dest.JobApplicationId, src => src.jobApplicationId)
            .Map(dest => dest.Location, src => src.location)
            .Map(dest => dest.StartTime, src => src.startTime)
            .Map(dest => dest.InterviewDate, src => src.interviewDate);
    }
}