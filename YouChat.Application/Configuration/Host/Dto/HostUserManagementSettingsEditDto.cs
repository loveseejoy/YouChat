using Abp.Runtime.Validation;

namespace YouChat.Configuration.Host.Dto
{
    public class HostUserManagementSettingsEditDto : IValidate
    {
        public bool IsEmailConfirmationRequiredForLogin { get; set; }
    }
}