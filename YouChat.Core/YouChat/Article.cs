using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouChat.Authorization.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouChat.YouChat
{
    public class Article :FullAuditedEntity<int, User>
    {
        [Required]
        public string Title { set; get; }
    
        public string Content { set; get; }

        public int  CategoryID { set; get; }

        [ForeignKey("CategoryID")]
        public  Category Category { set; get; }

    }
}
