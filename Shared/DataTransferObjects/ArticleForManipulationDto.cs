using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public abstract record ArticleForManipulationDto
    {
        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the title is 60 characters.")]
        public string? Title { get; init; }

        [Required(ErrorMessage = "Summary is a required field.")]
        [MaxLength(300, ErrorMessage = "Maximum length for the summary is 300 characters.")]
        public string? Summary { get; init; }
    }
}
