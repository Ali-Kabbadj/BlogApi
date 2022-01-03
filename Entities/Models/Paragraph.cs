using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Paragraph
    {
        [Column("ParagraphId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The paragraph must have a position")]
        //Have to make sure its unique at some point
        public int Position { get; set; }

        [Required(ErrorMessage = "Paragraph Title is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Paragraph Must have a body.")]
        [MaxLength(2000, ErrorMessage = "Maximum length for the Name is 2000 characters.")]
        public string? Body { get; set; }


        [ForeignKey(nameof(Article))]
        public Guid ArticleId { get; set; }
        public Article? Article { get; set; }
    }
}
