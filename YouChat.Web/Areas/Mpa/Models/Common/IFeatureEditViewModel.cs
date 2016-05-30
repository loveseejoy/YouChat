using System.Collections.Generic;
using Abp.Application.Services.Dto;
using YouChat.Editions.Dto;

namespace YouChat.Web.Areas.Mpa.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}