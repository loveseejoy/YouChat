using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YouChat.Authorization.Users.Dto;

namespace YouChat.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<ListResultOutput<UserLoginAttemptDto>> GetRecentUserLoginAttempts();
    }
}
