using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace YouChat.YouChat.Dto
{
    [AutoMapTo(typeof(Article))]
    public class CreateOrUpdateArticleDto: IInputDto
    {
        public int? Id { set; get; }
        [Required]
        public string Title { set; get; }

        public string Content { set; get; }

        public int CategoryId { set; get; }
    }
}
