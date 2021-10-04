using AutoMapper;
using platformService.Dtos;
using platformService.Models;

namespace platformService.Profiles{
    public class PlatformProfile:Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform,PlatformReadDto>();
            CreateMap<PlatFormCreateDtos,Platform>();
        }

    }
}