using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;

namespace JobSite.Application.InterviewSchedule.Queries.GetMyListInterviewSchedule;

public class GetMyListInterviewScheduleHander : IRequestHandler<GetMyListInterviewScheduleQuery, Result<List<GetMyListInterviewScheduleResponse>>>
{
    private readonly IInterviewScheduleRepository _interviewScheduleRepository;
    private readonly IUser _user;

    public GetMyListInterviewScheduleHander(IInterviewScheduleRepository interviewScheduleRepository, IUser user)
    {
        _interviewScheduleRepository = interviewScheduleRepository;
        _user = user;
    }

    public async Task<Result<List<GetMyListInterviewScheduleResponse>>> Handle(GetMyListInterviewScheduleQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _interviewScheduleRepository.GetListInterviewScheduleByUser(Guid.Parse(_user.Id!), cancellationToken);
            return Result<List<GetMyListInterviewScheduleResponse>>.Success(result);
        }
        catch (Exception ex)
        {
            throw new BadRequestException(ex.Message);
        }

    }
}