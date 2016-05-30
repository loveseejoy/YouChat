using System.Collections.Generic;
using YouChat.Authorization.Users.Dto;

namespace YouChat.Web.Areas.Mpa.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}