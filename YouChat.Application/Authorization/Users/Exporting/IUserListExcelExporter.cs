using System.Collections.Generic;
using YouChat.Authorization.Users.Dto;
using YouChat.Dto;

namespace YouChat.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}