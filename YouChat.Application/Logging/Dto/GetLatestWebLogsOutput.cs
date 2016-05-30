using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace YouChat.Logging.Dto
{
    public class GetLatestWebLogsOutput : IOutputDto
    {
        public List<string> LatesWebLogLines { get; set; }
    }
}
