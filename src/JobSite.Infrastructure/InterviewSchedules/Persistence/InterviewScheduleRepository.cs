using JobSite.Application.InterviewSchedule.Queries.GetListInterviewScheduleByJob;
using JobSite.Application.InterviewSchedule.Queries.GetMyListInterviewSchedule;
using JobSite.Infrastructure.Common.Persistence;

namespace JobSite.Infrastructure.InterviewSchedules.Persistence;

public class InterviewScheduleRepository : BaseRepository<InterviewSchedule>, IInterviewScheduleRepository
{
    public InterviewScheduleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<GetListInterviewScheduleByJobResponse>> GetListInterviewScheduleByJob(Guid jobId, CancellationToken cancellationToken)
    {
        var listInterview = await (
            from interview in _dbContext.InterviewSchedules
            join application in _dbContext.JobApplications on interview.JobApplicationId equals application.Id
            join resume in _dbContext.Resumes on application.ResumeId equals resume.Id
            join employee in _dbContext.Employees on resume.EmployeeId equals employee.Id
            join account in _dbContext.Accounts on employee.AccountId equals account.Id
            where application.JobId == jobId
            select new GetListInterviewScheduleByJobResponse(
                interview.Id,
                interview.Status,
                employee.Fullname,
                account.Email!,
                employee.Image ?? string.Empty
            )
        ).ToListAsync(cancellationToken);

        return listInterview;
    }


    public async Task<List<GetMyListInterviewScheduleResponse>> GetListInterviewScheduleByUser(Guid userId, CancellationToken cancellationToken)
    {
        var listInterview = await (
            from interview in _dbContext.InterviewSchedules
            join application in _dbContext.JobApplications on interview.JobApplicationId equals application.Id
            join job in _dbContext.Jobs on application.JobId equals job.Id
            join resume in _dbContext.Resumes on application.ResumeId equals resume.Id
            join employee in _dbContext.Employees on resume.EmployeeId equals employee.Id
            join account in _dbContext.Accounts on employee.AccountId equals account.Id
            join employer in _dbContext.Employers on application.JobId equals employer.Id
            where account.Id == userId

            select new GetMyListInterviewScheduleResponse(
                interview.Id,
                interview.InterviewDate,
                interview.StartTime,
                interview.Status,
                interview.Location!,
                job.Id,
                job.Title,
                job.Description ?? string.Empty,
                job.Salary,
                job.JobType,
                employer.Id,
                employer.Name,
                employer.Website ?? string.Empty
            )
        ).ToListAsync(cancellationToken);
        return listInterview!;
    }

}