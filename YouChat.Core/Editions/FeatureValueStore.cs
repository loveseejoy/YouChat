using Abp.Application.Features;
using YouChat.Authorization.Roles;
using YouChat.Authorization.Users;
using YouChat.MultiTenancy;

namespace YouChat.Editions
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager) 
            : base(tenantManager)
        {
        }
    }
}
