using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using YouChat.Authorization.Users;

namespace YouChat.Configuration.Host.Dto
{
    public class SendTestEmailInput : IInputDto
    {
        [Required]
        [MaxLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}