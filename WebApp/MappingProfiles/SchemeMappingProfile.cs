using AutoMapper;
using Domain.Schemes;
using WebApp.ViewModels.Schemes;

namespace WebApp.MappingProfiles;

public class SchemeMappingProfile : Profile
{
    public SchemeMappingProfile()
    {
        CreateMap<Scheme, SchemeVM>()
            .ForMember(
                dest => dest.ItemVMs,
                opt => opt.MapFrom(src => src.Items));
    }
}
