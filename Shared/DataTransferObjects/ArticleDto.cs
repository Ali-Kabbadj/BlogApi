using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ArticleDto
    {
        public Guid Id { get; init; }
        public string? Title { get; init; }
        public string? Summary { get; init; }
        public string? CreatedDateTime { get; init; }
    }
}
