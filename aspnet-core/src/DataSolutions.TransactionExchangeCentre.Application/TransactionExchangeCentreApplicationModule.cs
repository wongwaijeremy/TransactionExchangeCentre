using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DataSolutions.TransactionExchangeCentre.Authorization;

namespace DataSolutions.TransactionExchangeCentre
{
    [DependsOn(
        typeof(TransactionExchangeCentreCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TransactionExchangeCentreApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TransactionExchangeCentreAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TransactionExchangeCentreApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
