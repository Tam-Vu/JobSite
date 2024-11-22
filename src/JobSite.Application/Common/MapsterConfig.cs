
using JobSite.Application.Application.Common;
using JobSite.Application.Jobs.Commands.UpdateJob;
using Mapster;

namespace JobSite.Application.Common;

public class MapsterConfig : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        UpdateJobMappingConfig.Register(config);
    }
}