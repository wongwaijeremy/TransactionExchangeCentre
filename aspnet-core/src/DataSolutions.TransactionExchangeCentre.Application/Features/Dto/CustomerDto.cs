using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace DataSolutions.TransactionExchangeCentre.Features.Dto
{
    [AutoMap(typeof(Customer))]
    public class CustomerDto : EntityDto
    {
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public CustomerRoleType CustomerRole { get; set; }
    }
}
