using Abp.Authorization;
using DataSolutions.TransactionExchangeCentre.Authorization.Roles;
using DataSolutions.TransactionExchangeCentre.Authorization.Users;

namespace DataSolutions.TransactionExchangeCentre.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
