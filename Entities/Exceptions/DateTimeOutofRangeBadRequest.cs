using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class DateTimeOutofRangeBadRequest : BadRequestException
    {
        public DateTimeOutofRangeBadRequest()
            : base("Maximum date time should be less than 2099 and greater than 1999.")
        {
        }
    }
}
