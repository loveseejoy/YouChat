using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YouChat.Caching.Dto;

namespace YouChat.Caching
{
    public interface ICachingAppService : IApplicationService
    {
        ListResultOutput<CacheDto> GetAllCaches();

        Task ClearCache(IdInput<string> input);

        Task ClearAllCaches();
    }
}
