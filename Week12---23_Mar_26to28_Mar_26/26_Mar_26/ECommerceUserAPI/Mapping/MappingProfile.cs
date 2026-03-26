using AutoMapper;
using ECommerceUserAPI.Models;
using ECommerceUserAPI.DTOs;

namespace ECommerceUserAPI.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<RegisterDTO, User>();
    }
}