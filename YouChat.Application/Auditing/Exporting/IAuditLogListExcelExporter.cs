using System.Collections.Generic;
using YouChat.Auditing.Dto;
using YouChat.Dto;

namespace YouChat.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
