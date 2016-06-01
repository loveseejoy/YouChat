using System;
using System.Collections.Generic;
using System.Data.Entity;
using Abp.Domain.Repositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YouChat.YouChat.Dto;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.Extensions;
using System.Linq.Dynamic;

namespace YouChat.YouChat
{
    public class ArticleAppService : AbpZeroTemplateAppServiceBase, IArticleAppService
    {
        private readonly IRepository<Article> _articleRepository;

        public ArticleAppService(IRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task CreateOrUpdateArticle(CreateOrUpdateArticleInput input)
        {
            var article = input.MapTo<Article>();
            article.CategoryId = 1;
            await _articleRepository.InsertAsync(article);
        }

        public async Task<PagedResultOutput<ArticleListDto>> GetArticle(GetArticleInput input)
        {
            var query = _articleRepository.GetAll().Include(x=>x.Category)
                       .WhereIf(!input.Filter.IsNullOrEmpty(),x=>x.Title.Contains(input.Filter));

            var count = await query.CountAsync();


            var articles = await query
                           .OrderBy(input.Sorting)
                           .PageBy(input)
                           .ToListAsync();

           var articleListOutput = articles.Select(x =>
            {
                var dto = x.MapTo<ArticleListDto>();
                dto.CategoryName = x.Category.Name;
                return dto;
            }).ToList();

            return new PagedResultOutput<ArticleListDto>(count, articleListOutput);
        }
    }
}
