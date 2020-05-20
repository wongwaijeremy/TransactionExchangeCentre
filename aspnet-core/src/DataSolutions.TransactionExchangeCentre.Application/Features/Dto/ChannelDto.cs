using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;

namespace DataSolutions.TransactionExchangeCentre.Features.Dto
{
    [AutoMap(typeof(Channel))]
    public class ChannelDto : EntityDto, IHasCreationTime
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool Enable { get; set; }
        public DataDirectionType DataDirection { get; set; }
        public DocumentType DocumentType { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
