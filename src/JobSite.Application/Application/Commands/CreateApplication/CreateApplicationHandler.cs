using JobSite.Application.Application.Common;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using MapsterMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JobSite.Application.Application.Commands.CreateApplication;

public class CreateApplicationHandler : IRequestHandler<CreateApplicationCommand, Result<CommandApplicationResponse>>
{
    private readonly IJobApplicationRepository _jobApplicationRepository;
    private readonly IMapper _mapper;
    public CreateApplicationHandler(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
    {
        _jobApplicationRepository = jobApplicationRepository;
        _mapper = mapper;
    }
    public async Task<Result<CommandApplicationResponse>> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var newApplication = _mapper.Map<JobApplication>(request);
            await _jobApplicationRepository.AddAsync(newApplication, cancellationToken);
            return Result<CommandApplicationResponse>.Success(_mapper.Map<CommandApplicationResponse>(newApplication));
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}
