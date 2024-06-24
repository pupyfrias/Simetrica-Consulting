using AutoMapper;
using SimetricaConsulting.Application.Models.Dtos.V1.User;
using SimetricaConsulting.Identity.Entities;

namespace SimetricaConsulting.Identity.Mappings.V1
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserDetailDto>();
            CreateMap<User, UserListDto>();

        }
    }
}