using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace YouChat.Localization.Dto
{
    public class CreateOrUpdateLanguageInput : IInputDto
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}