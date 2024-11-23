

using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;

namespace JobSite.Application.InterviewSchedule.Queries.GetListInterviewScheduleByJob;

public class GetListInterviewScheduleByJobHandler : IRequestHandler<GetListInterviewScheduleByJobQuery, Result<List<GetListInterviewScheduleByJobResponse>>>
{
    private readonly IInterviewScheduleRepository _interviewScheduleRepository;
    public GetListInterviewScheduleByJobHandler(IInterviewScheduleRepository interviewScheduleRepository)
    {
        _interviewScheduleRepository = interviewScheduleRepository;
    }
    public async Task<Result<List<GetListInterviewScheduleByJobResponse>>> Handle(GetListInterviewScheduleByJobQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _interviewScheduleRepository.GetListInterviewScheduleByJob(request.JobId, cancellationToken);
            return Result<List<GetListInterviewScheduleByJobResponse>>.Success(response);
        }
        catch (Exception ex)
        {
            throw new BadRequestException(ex.Message);
        }
    }
}
