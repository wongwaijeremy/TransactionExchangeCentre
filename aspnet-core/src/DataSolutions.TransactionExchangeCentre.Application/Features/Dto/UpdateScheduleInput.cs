using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace DataSolutions.TransactionExchangeCentre.Features.Dto
{
    [AutoMapTo(typeof(Channel))]
    public class UpdateScheduleInput : EntityDto
    {
        public UploadIntervalOption UploadIntervalOption { get; set; }
        public int IntervalValue { get; set; }
        public DateTime? OnExactDayTime { get; set; }
    }
}
