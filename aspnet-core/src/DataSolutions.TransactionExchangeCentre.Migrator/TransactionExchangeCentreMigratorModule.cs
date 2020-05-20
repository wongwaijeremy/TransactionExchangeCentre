using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DataSolutions.TransactionExchangeCentre.Configuration;
using DataSolutions.TransactionExchangeCentre.EntityFrameworkCore;
using DataSolutions.TransactionExchangeCentre.Migrator.DependencyInjection;

namespace DataSolutions.TransactionExchangeCentre.Migrator
{
    [DependsOn(typeof(TransactionExchangeCentreEntityFrameworkModule))]
    public class TransactionExchangeCentreMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public TransactionExchangeCentreMigratorModule(TransactionExchangeCentreEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(TransactionExchangeCentreMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                TransactionExchangeCentreConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TransactionExchangeCentreMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
