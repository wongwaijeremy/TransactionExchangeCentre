using Abp.MultiTenancy;
using DataSolutions.TransactionExchangeCentre.Authorization.Users;

namespace DataSolutions.TransactionExchangeCentre.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
