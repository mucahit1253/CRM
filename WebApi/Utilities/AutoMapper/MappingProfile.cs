using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CampaignDtoForUpdate, Campaign>().ReverseMap();
            CreateMap<Campaign, CampaignDto>();
            CreateMap<CampaignDtoForInsertion, Campaign>();
            CreateMap<UserForRegistrationDto, User>();

        }
    }
}
