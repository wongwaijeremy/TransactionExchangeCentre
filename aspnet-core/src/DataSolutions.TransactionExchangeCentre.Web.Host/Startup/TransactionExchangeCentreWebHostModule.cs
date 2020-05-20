using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Threading.BackgroundWorkers;
using DataSolutions.TransactionExchangeCentre.Configuration;

namespace DataSolutions.TransactionExchangeCentre.Web.Host.Startup
{
    [DependsOn(
       typeof(TransactionExchangeCentreWebCoreModule),
        typeof(AbpHangfireAspNetCoreModule))]
    public class TransactionExchangeCentreWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TransactionExchangeCentreWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.BackgroundJobs.UseHangfire();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TransactionExchangeCentreWebHostModule).GetAssembly());
        }
    }
}
