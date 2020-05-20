using Abp.Application.Services;
using DataSolutions.TransactionExchangeCentre.Features.Dto;

namespace DataSolutions.TransactionExchangeCentre.Features
{
    public interface ICustomerAppService : IAsyncCrudAppService<CustomerDto, int, GetAllCustomersInput>
    {
    }
}
