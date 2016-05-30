using System.Threading.Tasks;
using Abp.Application.Services;
using YouChat.Configuration.Host.Dto;

namespace YouChat.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
