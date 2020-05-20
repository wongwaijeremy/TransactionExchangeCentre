using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace DataSolutions.TransactionExchangeCentre.Controllers
{
    public abstract class TransactionExchangeCentreControllerBase: AbpController
    {
        protected TransactionExchangeCentreControllerBase()
        {
            LocalizationSourceName = TransactionExchangeCentreConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
