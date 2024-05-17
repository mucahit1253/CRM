using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record CampaignDtoForUpdate(int Id,String Title, decimal AdvertPrice, DateTime StartDate, DateTime EndDate);
  
}
