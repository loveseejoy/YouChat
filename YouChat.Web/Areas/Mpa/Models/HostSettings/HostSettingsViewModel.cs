using System.Collections.Generic;
using Abp.Application.Services.Dto;
using YouChat.Configuration.Host.Dto;

namespace YouChat.Web.Areas.Mpa.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<ComboboxItemDto> EditionItems { get; set; }
    }
}