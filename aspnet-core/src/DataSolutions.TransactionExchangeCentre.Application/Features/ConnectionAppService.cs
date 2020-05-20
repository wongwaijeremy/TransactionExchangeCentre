using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using DataSolutions.TransactionExchangeCentre.Features.Dto;

namespace DataSolutions.TransactionExchangeCentre.Features
{
    [AbpAuthorize]
    public class ConnectionAppService : AsyncCrudAppService<Channel, ConnectionDto, int, PagedAndSortedResultRequestDto, 
        EntityDto, UpdateConnectionInput>, IConnectionAppService
    {
        public ConnectionAppService(
            IRepository<Channel> channelRepository)
            : base(channelRepository)
        {
        }
        
        public override Task<ConnectionDto> Get(EntityDto<int> input)
        {
            throw new NotSupportedException();
        }
        
        public override Task<ConnectionDto> Create(EntityDto input)
        {
            throw new NotSupportedException();
        }
        
        public override Task Delete(EntityDto<int> input)
        {
            throw new NotSupportedException();
        }
    }
}
