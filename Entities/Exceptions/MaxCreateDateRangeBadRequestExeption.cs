using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class MaxCreateDateRangeBadRequestExeption : BadRequestException
    {
        public MaxCreateDateRangeBadRequestExeption() :base("Range of searsh by the Articles Creation Date contains no elements")
        {}
    }
}