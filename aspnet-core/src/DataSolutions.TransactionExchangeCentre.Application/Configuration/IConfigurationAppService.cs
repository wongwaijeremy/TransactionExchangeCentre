using System.Threading.Tasks;
using DataSolutions.TransactionExchangeCentre.Configuration.Dto;

namespace DataSolutions.TransactionExchangeCentre.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
