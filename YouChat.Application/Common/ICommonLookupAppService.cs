using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YouChat.Common.Dto;

namespace YouChat.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultOutput<ComboboxItemDto>> GetEditionsForCombobox();

        Task<PagedResultOutput<NameValueDto>> FindUsers(FindUsersInput input);
    }
}