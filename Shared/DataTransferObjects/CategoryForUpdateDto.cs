using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CategoryForUpdateDto
    {
        [Required(ErrorMessage = "The name is a required field")]
        public string? Name { get; init; }
        public IEnumerable<ArticleForCreationDto>? Articles { get; init; }
    }
}
