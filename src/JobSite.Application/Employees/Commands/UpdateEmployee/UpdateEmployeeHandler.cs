using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.Employees.Common;
using JobSite.Application.IRepository;
using MapsterMapper;
using Microsoft.VisualBasic;

namespace JobSite.Application.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Result<EmployeeCommandRespose>>
{
    private readonly IMapper _mapper;
    private readonly IUser _user;
    private readonly IEmployeeRepository _employeeRepository;

    public UpdateEmployeeHandler(IUser user, IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _user = user;
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    public async Task<Result<EmployeeCommandRespose>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _employeeRepository.GetOneAsync(x => x.AccountId.ToString() == _user.Id, cancellationToken);
            _mapper.Map(request, employee);
            await _employeeRepository.UpdateAsync(employee, cancellationToken);
            var result = _mapper.Map<EmployeeCommandRespose>(employee);
            return Result<EmployeeCommandRespose>.Success(result);
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}