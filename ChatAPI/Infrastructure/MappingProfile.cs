using AutoMapper;
using ChatAPI.Dtos;
using ChatAPI.Models;

namespace ChatAPI.Infrastructure
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Message, MessageDto>()
                .ForMember(c => c.UserId, o => o.Ignore());
            CreateMap<NewMessageDto, Message>();
        }
    }
}