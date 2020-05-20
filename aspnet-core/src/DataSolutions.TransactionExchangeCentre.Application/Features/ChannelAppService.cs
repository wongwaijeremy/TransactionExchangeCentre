using System;
using System.Linq;
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
    public class ChannelAppService : AsyncCrudAppService<Channel, ChannelDto>, IChannelAppService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IChannelUploadScheduler _channelUploadScheduler;

        public ChannelAppService(
            IRepository<Channel> channelRepository,
            IRepository<Customer> customerRepository, 
            IChannelUploadScheduler channelUploadScheduler)
            : base(channelRepository)
        {
            _customerRepository = customerRepository;
            _channelUploadScheduler = channelUploadScheduler;
        }        

        protected override IQueryable<Channel> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return Repository.GetAllIncluding(channel => channel.Customer);
        }

        protected override ChannelDto MapToEntityDto(Channel entity)
        {
            var customerName = _customerRepository.Query(customers =>
                (from customer in customers
                where customer.Id == entity.CustomerId
                select customer.Name)
                .FirstOrDefault());
            var channelDto = base.MapToEntityDto(entity);
            channelDto.CustomerName = customerName;
            return channelDto;
        }

        public async Task Enable(EnableChannelInput input)
        {
            CheckUpdatePermission();

            var channel = await GetEntityByIdAsync(input.Id);
            channel.Enable = input.Enable;
            
            if (channel.Enable)
                _channelUploadScheduler.AddOrUpdate(channel);
            else
                _channelUploadScheduler.Disable(channel);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        //TODO search by Channel Name
    }
}
