using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Article
    {
        [Column("ArticleId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the title is 60 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Summary is a required field.")]
        [MaxLength(300, ErrorMessage = "Maximum length for the summary is 300 characters.")]
        public string? Summary { get; set; }

        public DateTime CreatedDate { get; set; }


        public ICollection<Paragraph>? Paragraphs { get; set; }

        public virtual ICollection<ArticleTag>? ArticleTags { get; set; }


        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
