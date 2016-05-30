using Abp.Authorization;
using YouChat.Authorization.Roles;
using YouChat.Authorization.Users;
using YouChat.MultiTenancy;

namespace YouChat.Authorization
{
    /// <summary>
    /// Implements <see cref="PermissionChecker"/>.
    /// </summary>
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
