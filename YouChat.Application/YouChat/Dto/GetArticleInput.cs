using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Runtime.Validation;
using YouChat.Dto;

namespace YouChat.YouChat.Dto
{
    public class GetArticleInput: PagedAndSortedInputDto, IShouldNormalize
    {

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "CreationTime desc";
            }
        }
    }
}
