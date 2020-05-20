using Abp.Application.Services;
using DataSolutions.TransactionExchangeCentre.Features.Dto;
using System.Threading.Tasks;

namespace DataSolutions.TransactionExchangeCentre.Features
{
    public interface IChannelAppService : IAsyncCrudAppService<ChannelDto>
    {
        Task Enable(EnableChannelInput input);
    }
}
