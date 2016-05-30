using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using YouChat.Authorization.Users;
using YouChat.MultiTenancy;

namespace YouChat.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}
