using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using DataSolutions.TransactionExchangeCentre.EntityFrameworkCore.Seed;

namespace DataSolutions.TransactionExchangeCentre.EntityFrameworkCore
{
    [DependsOn(
        typeof(TransactionExchangeCentreCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class TransactionExchangeCentreEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<TransactionExchangeCentreDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        TransactionExchangeCentreDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        TransactionExchangeCentreDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TransactionExchangeCentreEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
