using Abp.Notifications;
using YouChat.Dto;

namespace YouChat.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}