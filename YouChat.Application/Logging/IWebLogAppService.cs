using Abp.Application.Services;
using YouChat.Dto;
using YouChat.Logging.Dto;

namespace YouChat.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
