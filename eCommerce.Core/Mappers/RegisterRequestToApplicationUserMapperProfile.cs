

using AutoMapper;
using eCommerce.Core.DTO.Requests;
using eCommerce.Core.Entities;
using System.Net.Sockets;

namespace eCommerce.Core.Mappers;

public class RegisterRequestToApplicationUserMapperProfile:Profile
{
    public RegisterRequestToApplicationUserMapperProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>().ForMember(dest => dest.UserId, opt => opt.Ignore())
                                                     .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                                                     .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
                                                     .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                                                     .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));
        

        
    }
}
