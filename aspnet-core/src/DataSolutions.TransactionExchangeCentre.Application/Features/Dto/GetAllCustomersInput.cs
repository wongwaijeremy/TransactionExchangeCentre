using Abp.Application.Services.Dto;
using JetBrains.Annotations;

namespace DataSolutions.TransactionExchangeCentre.Features.Dto
{
    public class GetAllCustomersInput : PagedAndSortedResultRequestDto
    {
        [CanBeNull]
        public string Keywords { get; set; }
    }
}
