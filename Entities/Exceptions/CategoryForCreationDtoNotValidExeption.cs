using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CategoryForCreationDtoNotValidExeption : BadRequestException
    {
        public CategoryForCreationDtoNotValidExeption() : base("CategoryForCreationDto sent by the client is null or not valid")
        {
        }
    }
}
