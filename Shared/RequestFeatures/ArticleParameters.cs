using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class ArticleParameters : RequestParameters
    {
        
        public ArticleParameters() => OrderBy = "title";

        public DateTime MinCreatedDate { get; set; }
        public DateTime MaxCreatedDate { get; set; } = DateTime.MaxValue;
        public bool ValidCreatedDateRange => MaxCreatedDate > MinCreatedDate;


        public string? SearchTerm { get; set; }


    }
}
