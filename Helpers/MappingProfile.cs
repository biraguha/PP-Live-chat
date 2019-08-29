
using AutoMapper;
using livechat.Models;
using livechat.ViewModels;

namespace livechat.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<User, UserVM>().ReverseMap();
            CreateMap<User, UserVM>();
            CreateMap<Message, MessageVM>();
            CreateMap<Conversation, ConversationVM>()
                .ForMember(
                    dest => dest.Messages,
                    opt => opt.MapFrom(src => src.Messages)
                )
                .ForMember(
                    dest => dest.Authors,
                    opt => opt.Ignore()
                );
        }
    }
}