using System.Transactions;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;
using JobSite.Application.Resumes.Commands.Common;
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
        using (TransactionScope scope = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
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

                foreach (var skill in request.Skills)
                {
                    using (var skillScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
                    {
                        var insertSkill = skill.Adapt<Skill>();
                        resume.Skills.Add(insertSkill);
                        skillScope.Complete();
                    }
                }

                foreach (var experienceDetail in request.ExperienceDetails)
                {
                    using (var detailScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
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
                        detailScope.Complete();
                    }
                }
                await _resumeRepository.AddAsync(resume, cancellationToken);
                scope.Complete();

                return Result<ResponseResumeCommand>.Success(new ResponseResumeCommand(resume.Id, resume.Created, resume.LastModified));
            }
            catch (Exception exception)
            {
                scope.Dispose();
                throw new BadRequestException(exception.Message);
            }
        }
    }
};