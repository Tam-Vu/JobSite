using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using JobSite.Application.Jobs.Common;
using Mapster;
using MapsterMapper;

namespace JobSite.Application.Jobs.Commands.UpdateJob;

public class UpdateJobHandler : IRequestHandler<UpdateJobCommand, Result<JobCommandResponse>>
{
    private readonly IJobRepository _jobRepository;
    private readonly IMapper _mapper;
    public UpdateJobHandler(IJobRepository jobRepository, IMapper mapper)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
    }

    public async Task<Result<JobCommandResponse>> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.GetByIdAsync(request.id, cancellationToken);
        _mapper.Map(request, job);
        await _jobRepository.UpdateAsync(job, cancellationToken);
        return Result<JobCommandResponse>.Success(job.Adapt<JobCommandResponse>());
    }
}