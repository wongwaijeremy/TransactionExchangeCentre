using Abp.Application.Services.Dto;

namespace DataSolutions.TransactionExchangeCentre.Features.Dto
{
    public class EnableChannelInput : EntityDto
    {
        public bool Enable { get; set; }
    }
}
