using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace JobSite.Application.Resumes.Commands;

public class DeleteResumeHandler : IRequestHandler<DeleteResumeCommand, Result<string>>
{
    private readonly IResumeRepository _resumeRepository;
    private readonly IUser _user;
    private readonly IEmployeeRepository _employeeRepository;
    public DeleteResumeHandler(IResumeRepository resumeRepository, IUser user, IEmployeeRepository employeeRepository)
    {
        _resumeRepository = resumeRepository;
        _user = user;
        _employeeRepository = employeeRepository;
    }
    public async Task<Result<string>> Handle(DeleteResumeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _employeeRepository.GetOneAsync(x => x.AccountId.ToString() == _user.Id, cancellationToken);
            var resume = await _resumeRepository.GetOneAsync(x => x.Id == request.Id && x.EmployeeId == employee.Id, cancellationToken);
            await _resumeRepository.DeleteAsync(resume, cancellationToken);
            return Result<string>.Success("Resume deleted successfully");
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}
