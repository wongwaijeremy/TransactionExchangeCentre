using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using DataSolutions.TransactionExchangeCentre.Authorization;
using DataSolutions.TransactionExchangeCentre.Authorization.Roles;
using DataSolutions.TransactionExchangeCentre.Authorization.Users;
using DataSolutions.TransactionExchangeCentre.Editions;
using DataSolutions.TransactionExchangeCentre.MultiTenancy;

namespace DataSolutions.TransactionExchangeCentre.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
