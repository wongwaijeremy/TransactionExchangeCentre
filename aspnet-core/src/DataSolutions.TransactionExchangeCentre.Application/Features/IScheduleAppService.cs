using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DataSolutions.TransactionExchangeCentre.Features.Dto;

namespace DataSolutions.TransactionExchangeCentre.Features
{
    public interface IScheuldeAppService : IAsyncCrudAppService<ScheduleDto, int, PagedAndSortedResultRequestDto,
        ScheduleDto, UpdateScheduleInput>
    {
    }
}
