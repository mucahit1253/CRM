using Entities.Models;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using Repositories.EFCore.Extensions;


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

        public static IQueryable<Campaign> Sort(this IQueryable<Campaign> campaigns,
           string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return campaigns.OrderBy(b => b.Id);

            var orderQuery=OrderQueryBuilder
                .CreateOrderQuery<Campaign>(orderByQueryString);

            if (orderQuery is null)
                return campaigns.OrderBy(c=>c.Id);

            return campaigns.OrderBy(orderQuery);
        }



    }
   
}
