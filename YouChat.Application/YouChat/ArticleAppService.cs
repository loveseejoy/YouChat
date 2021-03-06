﻿using System;
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

        public async Task CreateOrUpdateArticle(CreateOrUpdateArticleDto input)
        {
            if (input.Id.HasValue)
            {
                var article = _articleRepository.Get(input.Id.Value);
                article = input.MapTo(article);
                article.CategoryId = 1;
                await _articleRepository.UpdateAsync(article);
            }
            else
            {
                var article = input.MapTo<Article>();
                article.CategoryId = 1;
                await _articleRepository.InsertAsync(article);
            }
        }


        public async Task<PagedResultOutput<ArticleListDto>> GetArticleList(GetArticleInput input)
        {
            var query = _articleRepository.GetAll().Include(x => x.Category).Include(x => x.CreatorUser)
                .WhereIf(!input.Filter.IsNullOrEmpty(), x => x.Title.Contains(input.Filter));
                      // .WhereIf(AbpSession.UserId!=2,x=>x.CreatorUser.Id==AbpSession.UserId); //这里要改
           
            var count = await query.CountAsync();


            var articles = await query
                           .OrderBy(input.Sorting)
                           .PageBy(input)
                           .ToListAsync();

           var articleListOutput = articles.Select(x =>
            {
                var dto = x.MapTo<ArticleListDto>();
                dto.CategoryName = x.Category.Name;
                dto.UserName = x.CreatorUser.UserName;
                return dto;
            }).ToList();

            return new PagedResultOutput<ArticleListDto>(count, articleListOutput);
        }

        public async Task<CreateOrUpdateArticleDto> GetArticle(NullableIdInput input)
        {
            if (input.Id.HasValue)  
            {
                var article = await _articleRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
                var articleOutput = article.MapTo<CreateOrUpdateArticleDto>();
                return articleOutput;
            }
            else
            {
                return new CreateOrUpdateArticleDto();
            }
        }

        public async Task DeleteArticle(EntityRequestInput input)
        {
           await _articleRepository.DeleteAsync(input.Id);
        }

        public  List<ArticleListDto> GetArticlAll()
        {
            var article =  _articleRepository.GetAll().Include(x => x.Category).Include(x => x.CreatorUser).OrderByDescending(x=>x.CreationTime).ToList();
            return article.Select(x =>
            {
                var dto = x.MapTo<ArticleListDto>();
                dto.CategoryName = x.Category.Name;
                dto.UserName = x.CreatorUser.Name;
                return dto;
            }).ToList();
        }

        public ArticleListDto GetArticleById(int Id)
        {
            var article = _articleRepository.GetAll().Include(x => x.Category).FirstOrDefault(x=>x.Id==Id);
            var articleDto = article.MapTo<ArticleListDto>();
            articleDto.UserName = article.CreatorUser.UserName;
            articleDto.CategoryName = article.Category.Name;
            return articleDto;
        }
    }
}
