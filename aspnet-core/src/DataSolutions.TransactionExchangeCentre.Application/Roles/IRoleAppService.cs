using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DataSolutions.TransactionExchangeCentre.Roles.Dto;

namespace DataSolutions.TransactionExchangeCentre.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
