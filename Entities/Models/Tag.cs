using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Tag
    {
        [Column("TagId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Tag Value is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the The Tag Value is 30 characters.")]
        public string? TagValue { get; set; }



        public virtual ICollection<ArticleTag>? TagArticles { get; set; }

    }
}
