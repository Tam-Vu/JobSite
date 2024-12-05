using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using Microsoft.AspNetCore.Authentication;

namespace JobSite.Application.Jobs.Commands.DeleteJob;

public class DeleteJobHandler : IRequestHandler<DeleteJobCommand, Result<string>>
{
    private readonly IJobRepository _jobRepository;
    public DeleteJobHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }
    public async Task<Result<string>> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var job = await _jobRepository.GetByIdAsync(request.Id, cancellationToken);
            await _jobRepository.DeleteAsync(job, cancellationToken);
            return Result<string>.Success("Job deleted successfully");
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}
