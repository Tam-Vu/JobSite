using JobSite.Application.Application.Common;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using MapsterMapper;

namespace JobSite.Application.Application.Commands.DeleteApplication;

public class DeleteApplicationHandler : IRequestHandler<DeleteApplicationCommand, Result<CommandApplicationResponse>>
{
    private readonly IJobApplicationRepository _jobApplicationRepository;
    private readonly IMapper _mapper;
    public DeleteApplicationHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
    {
        _jobApplicationRepository = jobApplicationRepository;
        _mapper = mapper;
    }
    public async Task<Result<CommandApplicationResponse>> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var deleteApplication = await _jobApplicationRepository.GetOneAsync(x => x.JobId == request.JobId && x.ResumeId == request.ResumeId, cancellationToken);
            await _jobApplicationRepository.DeleteAsync(deleteApplication, cancellationToken);
            return Result<CommandApplicationResponse>.Success(_mapper.Map<CommandApplicationResponse>(deleteApplication));
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}
