using AutoMapper;

namespace DataSolutions.TransactionExchangeCentre.Features.Dto
{
    public class FeatureMapProfile : Profile
    {
        public FeatureMapProfile()
        {
            CreateMap<ChannelDto, Channel>();
            CreateMap<ChannelDto, Channel>().ForMember(channel => channel.Customer, opt => opt.Ignore());
        }
    }
}
