using AutoMapper;
using CitasApp.Service.Entities;
using CitasApp.Service.DTOs;
using SQLitePCL;

namespace CitasApp.Service.Helpers;

public class AutoMapperProfiles : Profile {

    public AutoMapperProfiles() {
        CreateMap<AppUser, MemberDto>()
        .ForMember(dest => dest.PhotoUrl, 
            opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
        .ForMember(dest => dest.Age, 
            opt => opt.MapFrom(src => src.DameLaEdad()));
        CreateMap<Photo, PhotoDto>();
    }
    
}