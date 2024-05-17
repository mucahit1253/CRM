using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CampaingNotFoundException : NotFoundException
    {
        public CampaingNotFoundException(int id)
            : base($"The campaing with id : {id} could not found.")
        {
        }
    }
}
