using AutoMapper;
using Domain.Schemes;
using WebApp.ViewModels.Schemes;

namespace WebApp.MappingProfiles;

public class SchemeMappingProfile : Profile
{
    public SchemeMappingProfile()
    {
        CreateMap<Scheme, SchemeVM>();
    }
}
