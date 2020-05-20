using System.Linq;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using DataSolutions.TransactionExchangeCentre.Features.Dto;

namespace DataSolutions.TransactionExchangeCentre.Features
{
    [AbpAuthorize]
    public class CustomerAppService : AsyncCrudAppService<Customer, CustomerDto, int, GetAllCustomersInput>, ICustomerAppService
    {
        public CustomerAppService(IRepository<Customer> customerRepository)
            : base(customerRepository)
        {
        }

        protected override IQueryable<Customer> CreateFilteredQuery(GetAllCustomersInput input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(input.Keywords != null,
                    customer => customer.Name.Contains(input.Keywords) || customer.ShortCode.Contains(input.Keywords));
        }
    }
}
