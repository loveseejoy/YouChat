using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YouChat.YouChat.Dto;

namespace YouChat.YouChat
{
    public interface IArticleAppService: IApplicationService
    {
        Task CreateOrUpdateArticle(CreateOrUpdateArticleInput input);

        Task<PagedResultOutput<ArticleListDto>> GetArticle(GetArticleInput input);
    }
}
