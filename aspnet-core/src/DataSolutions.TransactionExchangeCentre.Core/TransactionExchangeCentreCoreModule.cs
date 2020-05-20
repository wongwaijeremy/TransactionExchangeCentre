using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using DataSolutions.TransactionExchangeCentre.Authorization.Roles;
using DataSolutions.TransactionExchangeCentre.Authorization.Users;
using DataSolutions.TransactionExchangeCentre.Configuration;
using DataSolutions.TransactionExchangeCentre.Localization;
using DataSolutions.TransactionExchangeCentre.MultiTenancy;
using DataSolutions.TransactionExchangeCentre.Timing;

namespace DataSolutions.TransactionExchangeCentre
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class TransactionExchangeCentreCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            TransactionExchangeCentreLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = TransactionExchangeCentreConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();

            //// Replace config
            //Configuration.ReplaceService<ISettingStore, ConfigFileSettingStore>(DependencyLifeStyle.Transient);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TransactionExchangeCentreCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
