namespace JobSite.Application.IRepository;

using JobSite.Application.InterviewSchedule.Queries.GetListInterviewScheduleByJob;
using JobSite.Application.InterviewSchedule.Queries.GetMyListInterviewSchedule;
using JobSite.Domain.Entities;
public interface IInterviewScheduleRepository : IBaseRepository<InterviewSchedule>
{
    Task<List<GetListInterviewScheduleByJobResponse>> GetListInterviewScheduleByJob(Guid jobId, CancellationToken cancellationToken);
    Task<List<GetMyListInterviewScheduleResponse>> GetListInterviewScheduleByUser(Guid userId, CancellationToken cancellationToken);
}