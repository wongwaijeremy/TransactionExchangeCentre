using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DataSolutions.TransactionExchangeCentre.MultiTenancy.Dto;

namespace DataSolutions.TransactionExchangeCentre.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
