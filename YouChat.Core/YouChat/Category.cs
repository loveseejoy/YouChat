using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChat.YouChat
{
    public class Category : Entity
    {
        public string Name { set; get; }

        public ICollection<Article> Articles { set; get; }
    }
}
