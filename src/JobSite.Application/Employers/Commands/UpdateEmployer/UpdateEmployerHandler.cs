using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.Employers.Common;
using JobSite.Application.IRepository;
using MapsterMapper;

namespace JobSite.Application.Employers.Commands.UpdateEmployer;

public class UpdateEmployerHandler : IRequestHandler<UpdateEmployerCommand, Result<EmployerCommandRespose>>
{
    private readonly IMapper _mapper;
    private readonly IUser _user;
    private readonly IEmployerRepository _employerRepository;

    public UpdateEmployerHandler(IUser user, IMapper mapper, IEmployerRepository employerRepository)
    {
        _user = user;
        _mapper = mapper;
        _employerRepository = employerRepository;
    }

    public async Task<Result<EmployerCommandRespose>> Handle(UpdateEmployerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employer = await _employerRepository.GetOneAsync(x => x.AccountId.ToString() == _user.Id, cancellationToken);
            _mapper.Map(request, employer);
            await _employerRepository.UpdateAsync(employer, cancellationToken);
            var result = _mapper.Map<EmployerCommandRespose>(employer);
            return Result<EmployerCommandRespose>.Success(result);
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}