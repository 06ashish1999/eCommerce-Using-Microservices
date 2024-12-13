﻿

using AutoMapper;
using eCommerce.Core.DTO.Responses;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers;

public class ApplicationUserToAuthenticationResponseMapperProfile:Profile
{
    public ApplicationUserToAuthenticationResponseMapperProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                                                            .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email))
                                                            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
                                                            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                                                            .ForMember(dest => dest.Success, opt => opt.Ignore())
                                                            .ForMember(dest => dest.Token, opt => opt.Ignore());
    }
}