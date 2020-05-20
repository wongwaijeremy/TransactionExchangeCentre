using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;

namespace DataSolutions.TransactionExchangeCentre.Features.Dto
{
    [AutoMap(typeof(Channel))]
    public class ScheduleDto : UpdateScheduleInput, IHasCreationTime
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
