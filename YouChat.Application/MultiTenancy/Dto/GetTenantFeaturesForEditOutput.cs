using System.Collections.Generic;
using Abp.Application.Services.Dto;
using YouChat.Editions.Dto;

namespace YouChat.MultiTenancy.Dto
{
    public class GetTenantFeaturesForEditOutput : IOutputDto
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}