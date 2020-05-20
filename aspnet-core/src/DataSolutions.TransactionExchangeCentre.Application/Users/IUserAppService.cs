using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DataSolutions.TransactionExchangeCentre.Roles.Dto;
using DataSolutions.TransactionExchangeCentre.Users.Dto;

namespace DataSolutions.TransactionExchangeCentre.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
