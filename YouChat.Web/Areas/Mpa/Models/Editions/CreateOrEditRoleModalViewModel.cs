using Abp.AutoMapper;
using YouChat.Editions.Dto;
using YouChat.Web.Areas.Mpa.Models.Common;

namespace YouChat.Web.Areas.Mpa.Models.Editions
{
    [AutoMapFrom(typeof(GetEditionForEditOutput))]
    public class CreateOrEditEditionModalViewModel : GetEditionForEditOutput, IFeatureEditViewModel
    {
        public bool IsEditMode
        {
            get { return Edition.Id.HasValue; }
        }

        public CreateOrEditEditionModalViewModel(GetEditionForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}