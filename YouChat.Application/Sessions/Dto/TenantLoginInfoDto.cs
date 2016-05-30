using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using YouChat.MultiTenancy;

namespace YouChat.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }

        public string EditionDisplayName { get; set; }
    }
}