using System.Threading.Tasks;
using Abp.Notifications;
using YouChat.Authorization.Users;
using YouChat.MultiTenancy;

namespace YouChat.Notifications
{
    public interface IAppNotifier
    {
        Task WelcomeToTheApplicationAsync(User user);

        Task NewUserRegisteredAsync(User user);

        Task NewTenantRegisteredAsync(Tenant tenant);

        Task SendMessageAsync(long userId, string message, NotificationSeverity severity = NotificationSeverity.Info);
    }
}
