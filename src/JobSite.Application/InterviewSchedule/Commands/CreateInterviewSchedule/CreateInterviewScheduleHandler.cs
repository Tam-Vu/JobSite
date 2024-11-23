using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.InterviewSchedule.Common;
using JobSite.Application.IRepository;
using JobSite.Domain.Enums;
using MapsterMapper;
namespace JobSite.Application.InterviewSchedule.Commands.CreateInterviewSchedule;
using JobSite.Domain.Entities;

public class CreateInterviewScheduleHandler : IRequestHandler<CreateInterviewScheduleCommand, Result<CommandsInterviewScheduleResponse>>
{
    private readonly IInterviewScheduleRepository _interviewScheduleRepository;
    private readonly IMapper _mapper;
    private readonly IJobApplicationRepository _jobApplicationRepository;

    public CreateInterviewScheduleHandler(IInterviewScheduleRepository interviewScheduleRepository, IMapper mapper, IJobApplicationRepository jobApplicationRepository)
    {
        _interviewScheduleRepository = interviewScheduleRepository;
        _mapper = mapper;
        _jobApplicationRepository = jobApplicationRepository;
    }

    public async Task<Result<CommandsInterviewScheduleResponse>> Handle(CreateInterviewScheduleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var application = await _jobApplicationRepository.GetByIdAsync(request.jobApplicationId, cancellationToken);
            if (application.Status != ApplicationStatus.Approved)
            {
                throw new BadRequestException("Application is not approved.");
            }

            var newInterviewSchedule = _mapper.Map<CreateInterviewScheduleCommand, InterviewSchedule>(request);
            await _interviewScheduleRepository.AddAsync(newInterviewSchedule, cancellationToken);
            var result = _mapper.Map<CommandsInterviewScheduleResponse>(newInterviewSchedule);
            return Result<CommandsInterviewScheduleResponse>.Success(result);
        }
        catch (Exception ex)
        {
            throw new BadRequestException(ex.Message);
        }
    }
}