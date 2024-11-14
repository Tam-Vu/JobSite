using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;

namespace JobSite.Application.Resumes.Commands.CreateResumeCommand;

public class CreateResumeHandler : IRequestHandler<CreateResumeCommand, Result<ResponseResumeCommand>>
{
    private readonly IResumeRepository _resumeRepository;
    private readonly IExperienceDetailsRepository _experienceDetailsRepository;
    private readonly IUser _user;
    private readonly IEmployeeRepository _employeeRepository;
    public CreateResumeHandler(IResumeRepository resumeRepository, IExperienceDetailsRepository experienceDetailsRepository, IUser user, IEmployeeRepository employeeRepository)
    {
        _resumeRepository = resumeRepository;
        _experienceDetailsRepository = experienceDetailsRepository;
        _user = user;
        _employeeRepository = employeeRepository;
    }
    public async Task<Result<ResponseResumeCommand>> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // var user = _user.GetAccount();
            var userId = _user.Id;
            var employee = await _employeeRepository.GetEmployeeByAccountIdAsync(userId!, cancellationToken);
            if (employee == null)
            {
                throw new Exception("You don't have permission to create a resume");
            }
            var test = employee.Id;
            var resume = new Resume
            {
                Title = request.Title,
                Experience = request.Experience,
                Education = request.Education,
                // File = request.File,
                EmployeeId = Guid.Parse(employee.Id.ToString())
            };

            foreach (var experienceDetail in request.ExperienceDetails)
            {

                resume.ExperienceDetails.Add
                (
                    new ExperienceDetail
                    {
                        CompanyName = experienceDetail.CompanyName,
                        StartYear = experienceDetail.StartYear,
                        StartMonth = experienceDetail.StartMonth,
                        EndYear = experienceDetail.EndYear,
                        EndMonth = experienceDetail.EndMonth,
                        Description = experienceDetail.Description,
                        ResumeId = resume.Id
                    }
                );
            }
            await _resumeRepository.AddAsync(resume, cancellationToken);

            return Result<ResponseResumeCommand>.Success(new ResponseResumeCommand(resume.Id, resume.Created, resume.LastModified));
        }
        catch (Exception exception)
        {
            throw new BadRequestException(exception.Message);
        }

    }
}