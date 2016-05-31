using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace YouChat.YouChat.Dto
{
    public class ArticleListDto: EntityDto
    {
        public string Title { set; get; }

        public string Content { set; get; }

        public string CategoryName { set; get; }
    }
}
