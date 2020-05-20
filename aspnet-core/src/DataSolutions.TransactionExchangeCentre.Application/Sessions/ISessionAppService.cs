using System.Threading.Tasks;
using Abp.Application.Services;
using DataSolutions.TransactionExchangeCentre.Sessions.Dto;

namespace DataSolutions.TransactionExchangeCentre.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
