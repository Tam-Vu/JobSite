using System.Transactions;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;
using JobSite.Application.Resumes.Common;
using Mapster;

namespace JobSite.Application.Resumes.Commands.UpdateResumeCommand;

public class UpdateResumeHandler : IRequestHandler<UpdateResumeCommand, Result<ResponseResumeCommand>>
{
    private readonly IResumeRepository _resumeRepository;
    private readonly IUser _user;
    private readonly IEmployeeRepository _employeeRepository;
    public UpdateResumeHandler(IResumeRepository resumeRepository, IUser user, IEmployeeRepository employeeRepository)
    {
        _resumeRepository = resumeRepository;
        _user = user;
        _employeeRepository = employeeRepository;
    }
    async Task<Result<ResponseResumeCommand>> IRequestHandler<UpdateResumeCommand, Result<ResponseResumeCommand>>.Handle(UpdateResumeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userId = _user.Id;
            var employee = await _employeeRepository.GetEmployeeByAccountIdAsync(userId!, cancellationToken);
            if (employee == null)
            {
                throw new Exception("You don't have permission to update a resume");
            }
            var resume = await _resumeRepository.GetByIdAsync(request.Id, cancellationToken);
            if (resume == null)
            {
                throw new NotFoundException("Resume not found");
            }
            if (resume.EmployeeId != employee.Id)
            {
                throw new UnauthorizedException("You don't have permission to update this resume");
            }
            resume.Title = request.Title;
            resume.Experience = request.Experience;
            resume.Education = request.Education;

            var ListRequestSkills = request.Skills.Adapt<List<Skill>>();
            var OldSkills = resume.Skills;
            //skill that are in the resume but not in the request list
            var deleteSkills = OldSkills.Except<Skill, Guid>(ListRequestSkills, x => x.Id).ToList();
            //skill that are in the request but not in the resume list
            var insertSkills = ListRequestSkills.Except<Skill, Guid>(OldSkills, x => x.Id).ToList();
            foreach (var skill in deleteSkills)
            {
                resume.Skills.Remove(skill);
            }
            foreach (var skill in insertSkills)
            {
                resume.Skills.Add(skill);
            }

            var ListRequestExperienceDetails = request.ExperienceDetails.Adapt<List<ExperienceDetail>>();
            var OldExperienceDetails = resume.ExperienceDetails;
            //experience details that are in the resume but not in the request list
            var deleteExperienceDetails = OldExperienceDetails.Except<ExperienceDetail, Guid>(ListRequestExperienceDetails, x => x.Id).ToList();
            //experience details that are in the request but not in the resume list
            var insertExperienceDetails = ListRequestExperienceDetails.Except<ExperienceDetail, Guid>(OldExperienceDetails, x => x.Id).ToList();
            foreach (var experienceDetail in deleteExperienceDetails)
            {
                resume.ExperienceDetails.Remove(experienceDetail);
            }
            foreach (var experienceDetail in insertExperienceDetails)
            {
                resume.ExperienceDetails.Add(experienceDetail);
            }

            await _resumeRepository.UpdateAsync(resume, cancellationToken);
            return Result<ResponseResumeCommand>.Success(new ResponseResumeCommand(resume.Id, resume.Created, resume.LastModified));
        }
        catch (Exception ex)
        {
            throw new BadRequestException(ex.Message);
        }
    }
}
