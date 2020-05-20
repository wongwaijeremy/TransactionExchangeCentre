using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using DataSolutions.TransactionExchangeCentre.Features.Dto;
using DataSolutions.TransactionExchangeCentre.Features.Uploading;


namespace DataSolutions.TransactionExchangeCentre.Features
{
    [AbpAuthorize]
    public class ScheuldeAppService : AsyncCrudAppService<Channel, ScheduleDto, int, PagedAndSortedResultRequestDto,
        ScheduleDto, UpdateScheduleInput>, IScheuldeAppService
    {
        private readonly IChannelUploadScheduler _channelUploadScheduler;

        public ScheuldeAppService(
            IRepository<Channel> channelRepository,
            IChannelUploadScheduler channelUploadScheduler)
            : base(channelRepository)
        {
            _channelUploadScheduler = channelUploadScheduler;
        }

        public override async Task<ScheduleDto> Update(UpdateScheduleInput input)
        {
            var currentChannel = await GetEntityByIdAsync(input.Id);
            if (!currentChannel.DoesNotChangeByInput(
                    input.UploadIntervalOption, input.IntervalValue, input.OnExactDayTime)
                && currentChannel.Enable)
            {
                MapToEntity(input, currentChannel);
                _channelUploadScheduler.AddOrUpdate(currentChannel);
            }
            return await base.Update(input);
        }

        public override Task<ScheduleDto> Get(EntityDto<int> input)
        {
            throw new NotSupportedException();
        }

        public override Task Delete(EntityDto<int> input)
        {
            throw new NotSupportedException();
        }

        public override Task<ScheduleDto> Create(ScheduleDto input)
        {
            throw new NotSupportedException();
        }
    }
}
