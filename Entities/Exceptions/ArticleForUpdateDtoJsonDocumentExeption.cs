using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class ArticleForUpdateDtoJsonDocumentExeption : BadRequestException
    {
        public ArticleForUpdateDtoJsonDocumentExeption() : base("Something when wrong while reading ArticleForUpdateDtoJsonDocument sent by the client")
        {
        }
    }
}
