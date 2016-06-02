using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace YouChat.YouChat.Dto
{
    [AutoMapFrom(typeof(Article))]
    public class ArticleListDto: EntityDto
    {
        public string Title { set; get; }

        public string Content { set; get; }

        public string CategoryName { set; get; }

        public DateTime CreationTime { set; get; }

        public string UserName { set; get; }
    }
}
