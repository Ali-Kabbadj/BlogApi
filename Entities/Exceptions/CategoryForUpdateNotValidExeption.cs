using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CategoryForUpdateNotValidExeption : BadRequestException
    {
        public CategoryForUpdateNotValidExeption() : base("CategoryForUpdate sent from the client is null or Not Valid!!")
        {
        }
    }
}
