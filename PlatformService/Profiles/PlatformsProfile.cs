using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform, PlatformReadDto>()
                .ForMember(x => x.Id, x => x.MapFrom(z => z.Id))
                .ForMember(x => x.Name, x => x.MapFrom(z => z.Name))
                .ForMember(x => x.Publisher, x => x.MapFrom(z => z.Publisher))
                .ForMember(x => x.Cost, x => x.MapFrom(z => z.Cost));

            CreateMap<PlatformCreateDto, Platform>()
                .ForMember(x => x.Name, x => x.MapFrom(z => z.Name))
                .ForMember(x => x.Publisher, x => x.MapFrom(z => z.Publisher))
                .ForMember(x => x.Cost, x => x.MapFrom(z => z.Cost));
        }
    }
}
