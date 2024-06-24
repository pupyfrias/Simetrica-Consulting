using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SimetricaConsulting.Application.Models.Dtos.V1.Role;

namespace SimetricaConsulting.Identity.Mappings.V1
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole, RoleListDto>();
        }
    }
}