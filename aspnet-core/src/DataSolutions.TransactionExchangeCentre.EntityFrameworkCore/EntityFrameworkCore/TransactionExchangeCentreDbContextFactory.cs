using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DataSolutions.TransactionExchangeCentre.Configuration;
using DataSolutions.TransactionExchangeCentre.Web;

namespace DataSolutions.TransactionExchangeCentre.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TransactionExchangeCentreDbContextFactory : IDesignTimeDbContextFactory<TransactionExchangeCentreDbContext>
    {
        public TransactionExchangeCentreDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TransactionExchangeCentreDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TransactionExchangeCentreDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TransactionExchangeCentreConsts.ConnectionStringName));

            return new TransactionExchangeCentreDbContext(builder.Options);
        }
    }
}
