using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public static class CampaignRepositoryExtensions
    {
        public static IQueryable<Campaign> FilterCampaign(this IQueryable<Campaign> campaigns,
            DateTime startDate, DateTime endDate) =>
        campaigns.Where(campaigns =>
            (campaigns.EndDate <= endDate) &&
           (campaigns.StartDate >= startDate));
    }
}
