using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Repositories.EfCore.Extensions
{
    public static class CampaignRepositoryExtensions
    {
        public static IQueryable<Campaign> FilterCampaign(this IQueryable<Campaign> campaigns,
            DateTime startDate, DateTime endDate) =>
        campaigns.Where(campaigns =>
            campaigns.EndDate <= endDate &&
           campaigns.StartDate >= startDate);

        public static IQueryable<Campaign> Search(this IQueryable<Campaign> campaigns,
            string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return campaigns;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return campaigns
                    .Where(b => b.Title
                    .ToLower()
                    .Contains(searchTerm));
        }
    }
   
}
