using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.InterviewSchedule.Common;
using JobSite.Application.IRepository;
using JobSite.Domain.Enums;
using MapsterMapper;

namespace JobSite.Application.InterviewSchedule.Commands.ApproveInterviewSchedule;

public class ApproveInterviewScheduleHandler : IRequestHandler<ApproveInterviewScheduleCommand, Result<CommandsInterviewScheduleResponse>>
{
    private readonly IInterviewScheduleRepository _interviewScheduleRepository;
    private readonly IMapper _mapper;
    public ApproveInterviewScheduleHandler(IInterviewScheduleRepository interviewScheduleRepository, IMapper mapper)
    {
        _interviewScheduleRepository = interviewScheduleRepository;
        _mapper = mapper;
    }
    public async Task<Result<CommandsInterviewScheduleResponse>> Handle(ApproveInterviewScheduleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var interviewSchedule = await _interviewScheduleRepository.GetByIdAsync(request.id, cancellationToken);
            if (request.method == 0)
            {
                interviewSchedule.Status = InterviewStatus.Completed;
                await _interviewScheduleRepository.UpdateAsync(interviewSchedule, cancellationToken);
            }
            else
            {
                interviewSchedule.Status = InterviewStatus.Cancelled;
                await _interviewScheduleRepository.UpdateAsync(interviewSchedule, cancellationToken);
            }
            var result = _mapper.Map<CommandsInterviewScheduleResponse>(interviewSchedule);
            return Result<CommandsInterviewScheduleResponse>.Success(result);
        }
        catch (Exception ex)
        {
            throw new BadRequestException(ex.Message);
        }
    }
}
