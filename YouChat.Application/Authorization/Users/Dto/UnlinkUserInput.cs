using Abp.Application.Services.Dto;

namespace YouChat.Authorization.Users.Dto
{
    public class UnlinkUserInput : IInputDto
    {
        public long UserId { get; set; }
    }
}