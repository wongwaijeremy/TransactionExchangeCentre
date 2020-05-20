using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DataSolutions.TransactionExchangeCentre.Authorization.Roles;
using DataSolutions.TransactionExchangeCentre.Authorization.Users;
using DataSolutions.TransactionExchangeCentre.MultiTenancy;
using DataSolutions.TransactionExchangeCentre.Features;

namespace DataSolutions.TransactionExchangeCentre.EntityFrameworkCore
{
    public class TransactionExchangeCentreDbContext : AbpZeroDbContext<Tenant, Role, User, TransactionExchangeCentreDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Channel> Channels { get; set; }

        public TransactionExchangeCentreDbContext(DbContextOptions<TransactionExchangeCentreDbContext> options)
            : base(options)
        {
        }
    }
}
