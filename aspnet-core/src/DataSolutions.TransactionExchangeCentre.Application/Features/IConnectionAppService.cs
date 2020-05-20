using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DataSolutions.TransactionExchangeCentre.Features.Dto;

namespace DataSolutions.TransactionExchangeCentre.Features
{
    public interface IConnectionAppService : IAsyncCrudAppService<ConnectionDto, int, PagedAndSortedResultRequestDto,
        EntityDto, UpdateConnectionInput>
    {
    }
}
