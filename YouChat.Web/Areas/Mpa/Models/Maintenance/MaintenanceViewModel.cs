using System.Collections.Generic;
using YouChat.Caching.Dto;

namespace YouChat.Web.Areas.Mpa.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}