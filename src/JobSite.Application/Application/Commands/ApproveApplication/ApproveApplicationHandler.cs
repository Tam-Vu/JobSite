using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using JobSite.Domain.Enums;

namespace JobSite.Application.Application.Commands.ApproveApplication;

public class ApproveApplicationHandler : IRequestHandler<ApproveApplicationCommand, Result<string>>
{
    private readonly IJobApplicationRepository _jobApplicationRepository;
    public ApproveApplicationHandler(IJobApplicationRepository jobApplicationRepository)
    {
        _jobApplicationRepository = jobApplicationRepository;
    }
    public async Task<Result<string>> Handle(ApproveApplicationCommand request, CancellationToken cancellationToken)
    {
        var application = await _jobApplicationRepository.GetByIdAsync(request.Id, cancellationToken);
        if (request.Status == 0)
        {
            application.Status = ApplicationStatus.Approved;
            await _jobApplicationRepository.UpdateAsync(application, cancellationToken);
            return Result<string>.Success("Application has been approved");
        }
        else
        {
            application.Status = ApplicationStatus.Rejected;
            await _jobApplicationRepository.UpdateAsync(application, cancellationToken);
            return Result<string>.Success("Application has been rejected");
        }
    }
}
