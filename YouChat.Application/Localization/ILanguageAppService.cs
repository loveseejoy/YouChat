using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YouChat.Localization.Dto;

namespace YouChat.Localization
{
    public interface ILanguageAppService : IApplicationService
    {
        Task<GetLanguagesOutput> GetLanguages();

        Task<GetLanguageForEditOutput> GetLanguageForEdit(NullableIdInput input);

        Task CreateOrUpdateLanguage(CreateOrUpdateLanguageInput input);

        Task DeleteLanguage(IdInput input);

        Task SetDefaultLanguage(SetDefaultLanguageInput input);

        Task<PagedResultOutput<LanguageTextListDto>> GetLanguageTexts(GetLanguageTextsInput input);

        Task UpdateLanguageText(UpdateLanguageTextInput input);
    }
}
