using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using JobSite.Application.Jobs.Common;
using Mapster;

namespace JobSite.Application.Jobs.Commands.UpdateJob;

public class UpdateJobHandler : IRequestHandler<UpdateJobCommand, Result<JobCommandResponse>>
{
    private readonly IJobRepository _jobRepository;
    public UpdateJobHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<Result<JobCommandResponse>> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.GetByIdAsync(request.id, cancellationToken);
        var updateJob = request.Adapt(job);

        await _jobRepository.UpdateAsync(updateJob, cancellationToken);

        return Result<JobCommandResponse>.Success(updateJob.Adapt<JobCommandResponse>());
    }
}