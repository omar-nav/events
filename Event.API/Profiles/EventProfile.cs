using AutoMapper;

namespace Event.API.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Entities.EventEntity, Models.EventDto>();
            CreateMap<Models.EventCreationDto, Entities.EventEntity>();
            CreateMap<Models.EventForUpdateDto, Entities.EventEntity>();
            CreateMap<Entities.EventEntity, Models.EventForUpdateDto>();
        }
    }
}
