using AutoMapper;
using IdentityServer.DAL.Model;
using IdentityServer.Dtos;

namespace IdentityServer.Infrastructure
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();
        }
    }
}