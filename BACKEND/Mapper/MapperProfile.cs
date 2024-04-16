using BACKEND.Models.DTOs;
using BACKEND.Models;
using AutoMapper;

namespace BACKEND.Mapper
{


    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //USER
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserGetDto>();

        }
    }
}
