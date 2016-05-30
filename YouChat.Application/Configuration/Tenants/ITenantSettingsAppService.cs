using System.Threading.Tasks;
using Abp.Application.Services;
using YouChat.Configuration.Tenants.Dto;

namespace YouChat.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);
    }
}
