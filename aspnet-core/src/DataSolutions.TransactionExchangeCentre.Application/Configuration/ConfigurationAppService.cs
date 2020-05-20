using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using DataSolutions.TransactionExchangeCentre.Configuration.Dto;

namespace DataSolutions.TransactionExchangeCentre.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TransactionExchangeCentreAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
