using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YouChat.Auditing.Dto;
using YouChat.Dto;

namespace YouChat.Auditing
{
    public interface IAuditLogAppService : IApplicationService
    {
        Task<PagedResultOutput<AuditLogListDto>> GetAuditLogs(GetAuditLogsInput input);

        Task<FileDto> GetAuditLogsToExcel(GetAuditLogsInput input);
    }
}