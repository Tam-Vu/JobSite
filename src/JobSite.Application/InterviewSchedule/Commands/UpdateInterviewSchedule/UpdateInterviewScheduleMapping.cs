using Mapster;

namespace JobSite.Application.InterviewSchedule.Commands.CreateInterviewSchedule;

using JobSite.Application.InterviewSchedule.Commands.UpdateInterviewSchedule;
using JobSite.Domain.Entities;
public class UpadateInterviewScheduleMappingConfig
{
    public static void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateInterviewScheduleCommand, InterviewSchedule>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.Location, src => src.location)
            .Map(dest => dest.StartTime, src => src.startTime)
            .Map(dest => dest.InterviewDate, src => src.interviewDate);
    }
}