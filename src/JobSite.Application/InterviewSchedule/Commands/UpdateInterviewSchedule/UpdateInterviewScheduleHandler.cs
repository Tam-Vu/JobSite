using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.InterviewSchedule.Common;
using JobSite.Application.IRepository;
using Mapster;
using MapsterMapper;

namespace JobSite.Application.InterviewSchedule.Commands.UpdateInterviewSchedule;

public class UpdateInterviewScheduleHandler : IRequestHandler<UpdateInterviewScheduleCommand, Result<CommandsInterviewScheduleResponse>>
{
    private readonly IMapper _mapper;
    private readonly IInterviewScheduleRepository _interviewScheduleRepository;
    public UpdateInterviewScheduleHandler(IMapper mapper, IInterviewScheduleRepository interviewScheduleRepository)
    {
        _mapper = mapper;
        _interviewScheduleRepository = interviewScheduleRepository;
    }
    public async Task<Result<CommandsInterviewScheduleResponse>> Handle(UpdateInterviewScheduleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var interviewSchedule = await _interviewScheduleRepository.GetByIdAsync(request.id, cancellationToken);
            _mapper.Map(request, interviewSchedule);
            await _interviewScheduleRepository.UpdateAsync(interviewSchedule, cancellationToken);
            var result = _mapper.Map<CommandsInterviewScheduleResponse>(interviewSchedule);
            return Result<CommandsInterviewScheduleResponse>.Success(result);
        }
        catch (Exception ex)
        {
            throw new BadRequestException(ex.Message);
        }
    }
}
