using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;
using JobSite.Application.Resumes.Common;
using Mapster;


namespace JobSite.Application.Resumes.Commands.CreateResumeCommand;

public class CreateResumeHandler : IRequestHandler<CreateResumeCommand, Result<ResponseResumeCommand>>
{
    private readonly IResumeRepository _resumeRepository;
    private readonly IUser _user;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ISkillRepository _skillRepository;
    public CreateResumeHandler(IResumeRepository resumeRepository, IUser user, IEmployeeRepository employeeRepository, ISkillRepository skillRepository)
    {

        _resumeRepository = resumeRepository;
        _user = user;
        _employeeRepository = employeeRepository;
        _skillRepository = skillRepository;
    }
    public async Task<Result<ResponseResumeCommand>> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userId = _user.Id;
            var employee = await _employeeRepository.GetEmployeeByAccountIdAsync(userId!, cancellationToken);
            if (employee == null)
            {
                throw new Exception("You don't have permission to create a resume");
            }
            var resume = new Resume
            {
                Title = request.Title,
                Experience = request.Experience,
                Education = request.Education,
                // File = request.File,
                EmployeeId = employee.Id,
            };

            var skillConfigMapper = new TypeAdapterConfig();
            skillConfigMapper.NewConfig<SkillCommand, Skill>()
            .Map(dest => dest.Name, src => src.name)
            .Map(dest => dest.Id, src => src.id);
            foreach (var skill in request.Skills)
            {
                var insertSkill = skill.Adapt<Skill>(skillConfigMapper);
                await _skillRepository.Attach(insertSkill);
                resume.Skills.Add(insertSkill);
            }

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
};