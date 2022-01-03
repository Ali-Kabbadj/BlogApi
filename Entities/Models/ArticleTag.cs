using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ArticleTag
    {
        [Column("ArticleId")]
        public Guid ArticleId { get; set; }

        [Column("TagId")]
        public Guid TagId { get; set; }



        [ForeignKey("ArticleId")]
        public Article? Acticle { get; set; }


        [ForeignKey("TagId")]
        public Tag? Tag { get; set; }
    }
}
