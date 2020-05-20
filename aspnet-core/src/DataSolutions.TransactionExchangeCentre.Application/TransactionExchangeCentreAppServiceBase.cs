using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using DataSolutions.TransactionExchangeCentre.Authorization.Users;
using DataSolutions.TransactionExchangeCentre.MultiTenancy;

namespace DataSolutions.TransactionExchangeCentre
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class TransactionExchangeCentreAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected TransactionExchangeCentreAppServiceBase()
        {
            LocalizationSourceName = TransactionExchangeCentreConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
