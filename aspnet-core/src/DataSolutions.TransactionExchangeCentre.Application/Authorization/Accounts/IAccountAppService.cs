using System.Threading.Tasks;
using Abp.Application.Services;
using DataSolutions.TransactionExchangeCentre.Authorization.Accounts.Dto;

namespace DataSolutions.TransactionExchangeCentre.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
