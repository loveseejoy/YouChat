using System.Threading.Tasks;
using Abp.Application.Services;
using YouChat.Sessions.Dto;

namespace YouChat.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
