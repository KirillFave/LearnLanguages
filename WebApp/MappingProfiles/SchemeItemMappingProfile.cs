using AutoMapper;
using Domain.Schemes;
using WebApp.ViewModels.Schemes;

namespace WebApp.MappingProfiles;

public class SchemeItemMappingProfile : Profile
{
    public SchemeItemMappingProfile()
    {
        CreateMap<SchemeItem, SchemeItemVM>();
    }
}