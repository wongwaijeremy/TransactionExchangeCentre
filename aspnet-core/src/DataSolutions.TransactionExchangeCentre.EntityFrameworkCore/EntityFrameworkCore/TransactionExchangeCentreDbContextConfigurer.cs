using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DataSolutions.TransactionExchangeCentre.EntityFrameworkCore
{
    public static class TransactionExchangeCentreDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TransactionExchangeCentreDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TransactionExchangeCentreDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
