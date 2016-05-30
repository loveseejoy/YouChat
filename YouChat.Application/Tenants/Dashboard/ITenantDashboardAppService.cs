using Abp.Application.Services;
using YouChat.Tenants.Dashboard.Dto;

namespace YouChat.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
